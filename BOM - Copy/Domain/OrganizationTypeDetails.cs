using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOM.Domain
{
    public class OrganizationTypeDetails
    {
        public int OrganizationTypeID { get; set; }
        public string OrganizationType { get; set; }
        public override string ToString()
        {
            return String.Format("{0}{1}", OrganizationTypeID, OrganizationType);
        }
    }
}
