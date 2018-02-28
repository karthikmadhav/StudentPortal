using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
   public class QuoteDetails
    {
        public int CustomerID { get; set; }
        public string PrimaryMailID { get; set; }
        public string PrimaryPhoneNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNo { get; set; }
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
        public List<CustomerDetails> custList { get; set; }
        public List<QuoteItems> QuoteItemsList { get; set; }
        public double TotalAmount { get; set; }
    }
    public class QuoteItems
    {
        public int QuoteItemID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double ItemTotal { get; set; }
    }
}

