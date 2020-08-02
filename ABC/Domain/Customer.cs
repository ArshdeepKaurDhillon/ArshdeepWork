using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Domain
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", CustomerName, Address,
              City, Province, PostalCode);
        }
    }
}
