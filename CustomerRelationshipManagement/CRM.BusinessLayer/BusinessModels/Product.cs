using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
   public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public char Status { get; set; }
    }
}
