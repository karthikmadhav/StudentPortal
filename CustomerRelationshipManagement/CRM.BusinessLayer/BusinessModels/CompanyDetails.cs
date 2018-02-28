﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
    public class CompanyDetails
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryMailID { get; set; }
        public string PrimaryPhoneNo { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public int IndustryCategoryId { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPincode { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPincode { get; set; }
        public decimal AnnualRevenue { get; set; }
        public List<IndustryCategory> IndustryCategoryList { get; set; }
        
    }
}
