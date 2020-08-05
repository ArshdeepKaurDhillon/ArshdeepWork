using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.Pages
{
    public class DeleteStudentModel : PageModel
    {
        [BindProperty]
        public string StudentId { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }

        public void OnGet()
        {
        }
        public void OnPostFirstAction()
        {
            Student EnrolledStudent;
            BCS RequestDirector = new BCS();
            EnrolledStudent = RequestDirector.FindStudent(StudentId);
            Message1 = EnrolledStudent.StudentId + "---" + EnrolledStudent.FirstName + "---" + EnrolledStudent.LastName + "---" + EnrolledStudent.Email;           

        }

        public void OnPostSecondAction()
        {
            BCS RequestDirector = new BCS();
            bool Confirmation;
            Confirmation = RequestDirector.RemoveStudent(StudentId);
            if (Confirmation)
            {
                Message2 = "Student Deleted";
            }
            else
            {
                Message2 = "Student not deleted";
            }
        }
    }
}