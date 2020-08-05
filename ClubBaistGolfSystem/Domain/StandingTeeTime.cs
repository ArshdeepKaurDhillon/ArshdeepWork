using System;
using System.Collections.Generic;
using System.Text;

namespace ClubBaistGolfSystem.Domain
{
   public class StandingTeeTime
    {
        public string MemberNumber { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberLastName { get; set; }
        public string DayOfWeek { get; set; }
        public string RequestedTeeTime { get; set; }
        public string RequestedStartDate { get; set; }
        public string RequestedEndDate { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} ", MemberNumber,MemberFirstName, MemberLastName, RequestedTeeTime, RequestedStartDate);
        }

    }
}
