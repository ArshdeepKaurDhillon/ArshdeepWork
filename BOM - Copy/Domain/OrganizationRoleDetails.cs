using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.Domain
{
    public class OrganizationRoleDetails
    {
        public int OrganizationRoleID { get; set; }
        public string OrganizationRole { get; set; }
        public override string ToString()
        {
            return String.Format("{0}{1}", OrganizationRoleID, OrganizationRole);
        }
    }
}
