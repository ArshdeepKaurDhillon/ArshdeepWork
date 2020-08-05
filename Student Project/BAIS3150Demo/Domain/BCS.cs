using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Demo.TechnicalServices;

namespace BAIS3150Demo.Domain
{
    class BCS
    {

        public bool CreateProgram(string ProgramCode, string Description)
        {
            bool Confirmation;
            Programs ProgramManager = new Programs();
            Confirmation = ProgramManager.AddProgram(ProgramCode, Description);
            return Confirmation;
        }

        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            bool Confirmation;
            Students StudentManager = new Students();
            Confirmation = StudentManager.AddStudent(acceptedStudent, programCode);
            return Confirmation;
        }
        public Program FindProgram(string ProgramCode)
        {
           Program ActiveProgram;

            Programs ProgramManager = new Programs();
            ActiveProgram = ProgramManager.GetProgram(ProgramCode);

            return ActiveProgram;
        }
        public Student FindStudent(string StudentId)
        {
            Student EnrolledStudent;
            Students StudentManager = new Students();
            EnrolledStudent = StudentManager.GetStudent(StudentId);
            return EnrolledStudent;
        }

        public bool ModifyStudent(Student EnrolledStudent)
        {
            bool Confirmation;
            Students StudentManager = new Students();
            Confirmation = StudentManager.UpdateStudent(EnrolledStudent);
            return Confirmation;
        }

        public bool RemoveStudent(string StudentId)
        {
            bool Confirmation1;
            Students StudentManager = new Students();
            Confirmation1 = StudentManager.DeleteStudent(StudentId);
            return Confirmation1;
        }





    }
}

    




