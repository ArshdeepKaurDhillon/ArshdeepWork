using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.TechnicalServices;
namespace ABC.Domain
{
    

    public class Sale
    {
       public string SaleNumber { get; set; }
        public string SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string Salesperson { get; set; }
        public string Subtotal { get; set; }
        public string Gst { get; set; }
        public string SaleTotal { get; set; }
        public string Time { get; set; }

         public class SaleItem:Sale
         {            
                public string ItemCode { get; set; }
                public string Quantity { get; set; }
                public string ItemTotal { get; set; }
         }
   
    }
}
