using System;
using System.Collections.Generic;
using System.Text;

namespace ClubBaistGolfSystem.Domain
{
    public class TeeTime
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string NumberOfCarts { get; set; }
        public string NumberOfPlayers { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public string Phone { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} ", Date, Time, PlayerFirstName, 
                PlayerLastName, Phone);
        }
    }
}
