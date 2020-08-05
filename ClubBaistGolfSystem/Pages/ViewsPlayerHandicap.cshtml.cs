using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.Domain;
namespace ClubBaistGolfSystem.Pages
{
    public class ViewsPlayerHandicapModel : PageModel
    {
        [BindProperty]
        public string MemberNumber { get; set; }

        public string Message { get; set; }
        
        public double HandicapFactor { get; set; }
        
        public void OnGet()
        {
            CBGS RequestDirector = new CBGS();
            HandicapFactor = RequestDirector.ViewHandicapFactor(MemberNumber);

            //var Truncated = Math.Truncate(HandicapFactor);
            
            //Message =HandicapFactor.ToString();
        
        }
    }
}
