using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.Domain;
using ClubBaistGolfSystem.Pages;

namespace ClubBaistGolfSystem.Pages
{
    public class ViewsMemberAccountModel : PageModel
    {
        [BindProperty]
        public string MemberAccountNumber { get; set; }       

        public List<MemberAccountEntry> newMemberAccountEntries { get; set; } = new List<MemberAccountEntry>();
        
        public string Message { get; set; }

        public void OnGet()
        {

        }
        public void OnPost()
        {
           
            CBGS RequestDirector = new CBGS();
            newMemberAccountEntries = RequestDirector.FindAccount(MemberAccountNumber).Entries;
        }
    }
}
