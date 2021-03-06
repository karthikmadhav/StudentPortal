﻿using CRM.DataAccessLayer.ConnectionManager;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers.DataModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Models;

namespace CRM.DataAccessLayer.Providers
{
    public class CustomerDetailsProvider : ICustomerProvider
    {
        ConnectionRepository connManager = new ConnectionRepository();
        public System.Data.SqlClient.SqlConnection con;
        #region Srored Procedure Name
        public string addNewCustomer = "usp_AddNewCustomer";
        public string getAllCustomer = "usp_GetAllCustomer";
        public string deleteCustomer = "usp_DeleteCustomer";
        public string updateCustomer = "usp_UpdateCustomer";
        public string getCustomerByID = "usp_GetCustomerByID";
        public string addKYCDocument = "usp_AddKYCDocument";
        public string getKYCDocument = "usp_GetKYCDocument";
        public string getAllKYCDocument = "usp_GetAllKYCDocument";
        #endregion

        System.Data.IDbConnection dbConnection;
        int rowsAffected = 0;

        public CustomerDetailsProvider()
        {
            dbConnection = connManager.GetConnection();
        }
        public List<DLCustomerDetails> GetCustomerList()
        {
            List<DLCustomerDetails> custDetails = new List<DLCustomerDetails>();
            try
            {
                con = connManager.GetConnection();
                con.Open();
                custDetails = SqlMapper.Query<DLCustomerDetails>(con, getAllCustomer).ToList();
                return custDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SaveCustomer(DLCustomerDetails customerDetails)
        {
            try
            {
                con = connManager.GetConnection();
                con.Open();
                con.Execute(addNewCustomer, customerDetails, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public bool DeleteCustomer(int customerID)
        {
            con = connManager.GetConnection();
            con.Open();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", customerID);

                rowsAffected = con.Execute(deleteCustomer, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateCustomer(DLCustomerDetails CustDetails)
        {
            con = connManager.GetConnection();
            con.Open();
            try
            {
                con.Execute(updateCustomer, CustDetails, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
       public DLCustomerDetails GetCustomerByID(int custID)
        {
            DLCustomerDetails customerDetails = new DLCustomerDetails();
            con = connManager.GetConnection();
            con.Open();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", custID);
                return customerDetails= dbConnection.Query<DLCustomerDetails>(getCustomerByID, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public int SaveKYC(KYCDetails kycDetails)
        {
            int kycID=0;
            try
            {
                con = connManager.GetConnection();
                con.Open();
                con.Execute(addKYCDocument, kycDetails, commandType: CommandType.StoredProcedure);
              List< KYCDetails>  kyc = SqlMapper.Query<KYCDetails>(con, getAllKYCDocument).ToList();
                kycID = kyc.Max(x => x.kycID);
                return kycID;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public List<KYCDetails> GetKYCByCustID(int custID)
        {
           List<KYCDetails> kycDetails = new List<KYCDetails>();
            con = connManager.GetConnection();
            con.Open();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", custID);
                kycDetails = SqlMapper.Query<KYCDetails>(con, getAllKYCDocument).ToList();
                if(kycDetails!=null && kycDetails.Count > 0)
                {
                    kycDetails = kycDetails.Where(x => x.customerID == custID).ToList();
                }
                return kycDetails;
                //return kycDetails = dbConnection.Query<KYCDetails>(getKYCDocument, param, commandType: CommandType.StoredProcedure).ToList();
                //return kycDetails = SqlMapper.Query<KYCDetails>(con, getKYCDocument, param).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
