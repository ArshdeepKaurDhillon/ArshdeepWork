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
    public class SubmitStandingTeeTimeRequestModel : PageModel
    {
        public List<StandingTeeTime> StandingTeeTimes { get; } = new List<StandingTeeTime>();

        public string Message { get; set; }

        [BindProperty]
        [Required]
        public string MemberNumber { get; set; }

        [BindProperty]
        public string MemberFirstName { get; set; }

        [BindProperty]
        public string MemberLastName { get; set; }

        [BindProperty]
        public string DayOfWeek { get; set; }

        [BindProperty]
        public string RequestedTeeTime { get; set; }

        [BindProperty]
        [Range(typeof(DateTime), "4/1/2020", "9/30/2020")]
        public string RequestedStartDate { get; set; }

        [BindProperty]
        [Range(typeof(DateTime), "4/1/2020", "9/30/2020")]
        public string RequestedEndDate { get; set; }

        public void OnGet()
        { 
        }

        public void OnPostFirstAction()
        {

            CBGS RequestDirector = new CBGS();

            DateTime date = DateTime.Parse(RequestedStartDate);
            
            StandingTeeTimes.AddRange(RequestDirector.ViewStandingTeeTime(date));

        }

        public void OnPostSecondAction()
        {
            StandingTeeTime RequestedStandingTeeTime = new StandingTeeTime();
            RequestedStandingTeeTime.MemberNumber = MemberNumber;
            RequestedStandingTeeTime.MemberFirstName = MemberFirstName;
            RequestedStandingTeeTime.MemberLastName = MemberLastName;
            RequestedStandingTeeTime.DayOfWeek = DayOfWeek;
            RequestedStandingTeeTime.RequestedTeeTime = RequestedTeeTime;
            RequestedStandingTeeTime.RequestedStartDate = RequestedStartDate;
            RequestedStandingTeeTime.RequestedEndDate = RequestedEndDate;

            bool Confirmation;
            CBGS RequestDirector = new CBGS();
            if (ModelState.IsValid)                         
            {
                Confirmation = RequestDirector.SubmitStandingTeeTime(RequestedStandingTeeTime);
                Message = "StandingTeeTimeRequest Submitted";
            }
            
            else
            {
                Message = "StandingTeeTimeRequest Not Submitted";
            }
        }
    }
}