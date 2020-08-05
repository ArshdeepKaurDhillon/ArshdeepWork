using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.Pages
{
    public class ModifyModel : PageModel
    {
        [BindProperty]
        public string StudentId { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string ProgramCode { get; set; }
       
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
            Student EnrolledStudent = new Student();
            EnrolledStudent.StudentId = StudentId;
            EnrolledStudent.FirstName = FirstName;
            EnrolledStudent.LastName = LastName;
            EnrolledStudent.Email = Email;
            EnrolledStudent.ProgramCode = ProgramCode;
            BCS RequestDirector = new BCS();
            bool Confirmation;
            Confirmation = RequestDirector.ModifyStudent(EnrolledStudent);

            if (Confirmation)
            {
                Message2 = "Student Modified";
            }
            else
            {
                Message2 = "Student not Modified";
            }
        }
    }
}