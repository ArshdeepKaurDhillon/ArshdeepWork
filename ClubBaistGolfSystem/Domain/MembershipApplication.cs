using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBaistGolfSystem.Domain
{
    public class MembershipApplication
    {

        public string MemberApplicationNumber { get; set; }
        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
        public string DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyPhone { get; set; }
        public string ShareholderName { get; set; }
        public string Date{ get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}  ", MemberApplicationNumber, FirstName, LastName,
                Status);
        }


    }
}
