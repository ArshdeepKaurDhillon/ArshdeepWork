using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace BAIS3150Demo.Pages
{
    public class ValidationDataAnnotationAttributesModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        [Required, MaxLength(5)]                             /*this property is defined within system.componentmodel.dataannotation*/
        public string Field { get; set; }


        public void OnGet()
        {
            Message = "**** OnGet ***";
        }

        public void OnPost()
        {
            if (ModelState.IsValid)                         //Every page model has model state
            {
                Message = "*** OnPost *** - Valid";
            }
            else
            {
                Message = "*** OnPost *** - Not Valid";
            }
        }

    }
}