using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIS3150Demo.Domain
{
    public class Program
    {
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public List<Student> EnrolledStudents { get; set; }
    }
}
