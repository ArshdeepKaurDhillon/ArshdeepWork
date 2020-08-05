using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3150Demo.Domain
{
    public class Student
    {
        private string _studentId; //CAMEL CASE PRECEDED WITH UNDERSCORE
        private string _firstName;


        public string StudentId //PASCAL CASE
        {
            get
            {
                return _studentId;

            }


            set
            {
                _studentId = value;
            }
        }


        public string FirstName //Expression-Bodied property accessors
        {
            get => _firstName; //implementation of property accessor can be made up of only a singlr statement
            set => _firstName = value;
        }


        public string LastName { get; set; } //Auto-Implemented Property, no logic in get/set
        public string Email { get; set; }

        public string ProgramCode { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", StudentId, FirstName,
               LastName, Email, ProgramCode);
        }
    }
}
