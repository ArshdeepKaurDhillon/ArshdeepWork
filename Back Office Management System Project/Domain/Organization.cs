using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOM.TechnicalServices;


namespace BOM.Domain
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public int CustomerID { get; set; }
        public string OrganizationName { get; set; }
        public int OrgTypeID { get; set; }
        public string OtherOrgType { get; set; }
        public string OtherOrgRole { get; set; }
        public int StatusID { get; set; }
        public List<Location> OrgLocations { get; set; }
        public string OrganizationType { get; set; }
        public int OrgCustomerID { get; set; }
        public override string ToString()
        {
            return String.Format("{0}", OrganizationName);
        }

        //	ORGANIZATION-CONTACT

        public int OrgContactID { get; set; }
        public int OrganizationRoleID { get; set; }
        public string PrimaryContact { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
