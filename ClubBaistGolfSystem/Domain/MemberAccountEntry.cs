using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBaistGolfSystem.Domain
{
    public class MemberAccountEntry
    {
        public string MemberNumber { get; set; }
        public double Amount { get; set; }
        public string ActivityDate { get; set; }
        public string PostedDate { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", MemberNumber, Amount, ActivityDate, PostedDate,Description);
        }
    }
}
