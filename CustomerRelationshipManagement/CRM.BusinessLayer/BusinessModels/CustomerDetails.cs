using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
   public class CustomerDetails
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        public string CustomerName { get; set; }
        public string PrimaryMailID { get; set; }
        [Required(ErrorMessage = "Phone No is Required")]
        public string PrimaryPhoneNo { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public int IndustryCategoryId { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string BillingAddress { get; set; }
        public string BillingAddress1 { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string BillingCity { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string BillingState { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        public string BillingCountry { get; set; }
        [Required(ErrorMessage = "Pincode is Required")]
        public string BillingPincode { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPincode { get; set; }
        public string ContactPersonName { get; set; }
        [Required(ErrorMessage = "Contact Name is Required")]
        public string ContactPersonNo { get; set; }
        public List<IndustryCategory> IndustryCategoryList { get; set; }
        public string GSTNO { get; set; }

    }
}
