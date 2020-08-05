using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.Domain
{
    public class Location
    {
        public int AddressTypeID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        // CUSTOMER-PERSON ONLY

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool PreferredEmail { get; set; }
        public bool PreferredPhone { get; set; }
        public bool PreferredAddress { get; set; }

        // CUSTOMER-ORGANIZATION ONLY

        public int OrgLocationID { get; set; }
        public int OrgCustomerID { get; set; }
        public string OrgLocationName { get; set; }
        public int OrgContactID { get; set; }
        public int NumerOfEmployees { get; set; }
        public bool IsNewLocation { get; set; }
        public bool PreferredLocation { get; set; }
    }
}
