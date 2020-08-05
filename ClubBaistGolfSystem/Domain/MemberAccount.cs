using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubBaistGolfSystem.Domain
{
    public class MemberAccount
    {
        public string MemberNumber { get; set; }
        public double Balance { get; set; }
      
        public List<MemberAccountEntry> Entries { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} ", MemberNumber, Balance);
        }
    }
}
