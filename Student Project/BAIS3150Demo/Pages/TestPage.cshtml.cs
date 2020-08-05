using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150Demo.Pages
{
    public class TestPageModel : PageModel
    {
        [BindProperty]
        public string Field { get; set; }

        public string Message { get; set; }

        public void OnGet() //initial
        {
            Message = "*** OnGeT ***";
        }


        public void OnPost()    //submit
        {
            Message = "*** OnPost***";
            //Field = Request.Form["Field"];

        }


    }
}
