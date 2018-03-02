using CRMPresentation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMPresentation.Repository
{
    public class MenuData
    {
        public static IList<Menu> GetMenus(string UserId)
        {
            /* using ado.net code */
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ToString()))
            {
                List<Menu> menuList = new List<Menu>();
                SqlCommand cmd = new SqlCommand("usp_GetMenuData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Menu menu = new Menu();
                    menu.MID = Convert.ToInt32(sdr["MID"].ToString());
                    menu.MenuName = sdr["MenuName"].ToString();
                    menu.MenuURL = sdr["MenuURL"].ToString();
                    menu.MenuParentID = Convert.ToInt32(sdr["MenuParentID"].ToString());
                    menu.ActionName = sdr["ActionName"].ToString();
                    menu.ControllerName = sdr["ControllerName"].ToString();
                    menu.IconStyle = sdr["IconStyle"].ToString();

                    menuList.Add(menu);
                }
                return menuList;
            }

            /* use can also use dapper orm
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString()))
            {
                try
                {
                    var para = new DynamicParameters();
                    para.Add("@UserId", UserId);
                    var MenuList = con.Query<Menu>("usp_GetMenuData", para, null, true, 0, CommandType.StoredProcedure);
                    return MenuList.ToList();
                }
                catch
                {
                    return null;
                }
            }*/
        }
    }
}