using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Demo.Pages
{
    public class TestPage1Model : PageModel
    {
        [BindProperty]
        public string Field1 { get; set; }

        [BindProperty]
        public string Field2 { get; set; }

        public string Message { get; set; }


        public void OnGet()
        {
            {
                Message = "*** OnGeT ***";
            }

        }

        public void OnPostFirstAction()
        {
            Message = "*** OnPostFirstAction ***";
        }

        public void OnPostSecondAction()
        {
            Message = "*** OnPostSecondAction ***";
        }

    }
}