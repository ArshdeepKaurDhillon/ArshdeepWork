using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.Pages
{
    public class FindStudentModel : PageModel
    {
        [BindProperty]
        public string StudentId { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Student EnrolledStudent;
            BCS RequestDirector = new BCS();
            EnrolledStudent = RequestDirector.FindStudent(StudentId);
            Message = EnrolledStudent.StudentId + "---" + EnrolledStudent.FirstName + "---" + EnrolledStudent.LastName + "---" + EnrolledStudent.Email;
        }

    }
}