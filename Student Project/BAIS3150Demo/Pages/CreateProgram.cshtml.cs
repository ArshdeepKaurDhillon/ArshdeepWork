using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.Pages
{
    public class CreateProgramModel : PageModel
    {
        [BindProperty]
        public string ProgramCode { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            bool Confirmation;
            BCS RequestDirector = new BCS();
            Confirmation = RequestDirector.CreateProgram(ProgramCode, Description);

            if (Confirmation)
            {
                Message = "Program Created";
            }

            else
            {
                Message = "Program is not created";
            }

        }
    }

}