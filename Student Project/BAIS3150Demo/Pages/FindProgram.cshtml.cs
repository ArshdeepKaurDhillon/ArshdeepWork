using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.Pages
{
    public class FindProgramModel : PageModel
    {
        [BindProperty]
        public string ProgramCode { get; set; }

        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        public string Message { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {

            BCS RequestDirector = new BCS();
            EnrolledStudents = RequestDirector.FindProgram(ProgramCode).EnrolledStudents;

        }
    }
}