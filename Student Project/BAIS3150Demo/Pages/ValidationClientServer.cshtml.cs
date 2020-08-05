using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Demo.Pages
{
    public class ValidationClientServerModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string InputField { get; set; }

        public void OnGet()
        {
            Message = "*** OnGet ***";
        }
        public void OnPost()
        {
            // validate InputField
            if(InputField == null || !(InputField.Length <=5))
            {
                ModelState.AddModelError("InputField", "InputField is required and can contain upto 5 characters");
            }

            if (ModelState.IsValid)
            {
                Message = "*** OnPost *** - Valid";
            }
            else
            {
                Message = " *** OnPost *** - InValid";
            }
        }
    }
}