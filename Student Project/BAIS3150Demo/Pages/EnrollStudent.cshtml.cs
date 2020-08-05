using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;
namespace BAIS3150Demo.Pages
{
    public class EnrollStudentModel : PageModel
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

        public string Message { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Student AcceptedStudent = new Student();
            AcceptedStudent.StudentId = StudentId;
            AcceptedStudent.FirstName = FirstName;
            AcceptedStudent.LastName = LastName;
            AcceptedStudent.Email = Email;

            bool Confirmation;
            BCS RequestDirector = new BCS();
            Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);



            if (Confirmation)
            {
                Message = "Student enrolled";
            }

            else
            {
                Message = "Student not enrolled";
            }
        }

    }
}