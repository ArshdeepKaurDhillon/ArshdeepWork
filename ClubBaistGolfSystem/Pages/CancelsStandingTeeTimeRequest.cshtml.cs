using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.Domain;
using System.ComponentModel.DataAnnotations;
using ClubBaistGolfSystem.TechnicalServices;

namespace ClubBaistGolfSystem.Pages
{
    public class CancelsStandingTeeTimeRequestModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "Please Enter Valid Member Number")]
        public string MemberNumber { get; set; }

        public void OnGet()
        {

        }

        public void OnPostFirstAction()
        {
            StandingTeeTime SearchedStandingTeeTime;
            CBGS RequestDirector = new CBGS();
            SearchedStandingTeeTime = RequestDirector.FindStandingTeeTime(MemberNumber);
            Message1 = SearchedStandingTeeTime.MemberFirstName + "---" + SearchedStandingTeeTime.MemberLastName;

        }

        public void OnPostSecondAction()
        {
            bool Confirmation;
            CBGS RequestDirector = new CBGS();
            //Confirmation = RequestDirector.RemoveStandingTeeTimeRequest(MemberNumber);

            //if (Confirmation)
            //{
            //    Message2 = "Standing TeeTime Request Deleted";
               


            //}

            //else
            //{
            //    Message2 = "Standing TeeTime Reques not Deleted";
              

            //}

            if (ModelState.IsValid)
            {
                Confirmation = RequestDirector.RemoveStandingTeeTimeRequest(MemberNumber);
                Message2 = "Standing TeeTime Request Deleted";
            }

            else
            {
                Message2 = "Standing TeeTime Reques not Deleted";
            }
        }
    }

}

