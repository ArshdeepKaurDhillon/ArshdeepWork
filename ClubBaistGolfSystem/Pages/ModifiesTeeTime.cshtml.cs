using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ClubBaistGolfSystem.Domain;
using ClubBaistGolfSystem.TechnicalServices;

namespace ClubBaistGolfSystem.Pages
{
    public class ModifiesTeeTimeModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }

        [BindProperty]
        [Required]
        public string Date { get; set; }

        [BindProperty]
        [Required]
        public string Time { get; set; }


        [BindProperty]
        [Required]
        public string PlayerFirstName { get; set; }

        [BindProperty]
        [Required]
        public string PlayerLastName { get; set; }

        [BindProperty]
        [Required]
        public string Phone { get; set; }


        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            TeeTime SelectedTime = new TeeTime();
            CBGS RequestDirector = new CBGS();

            DateTime date3 = DateTime.Parse(Date);
            DateTime time = DateTime.Parse(Time);
            //var time = Convert.ToDateTime(Time);

            SelectedTime = RequestDirector.ViewTeeTime(date3, time);
            Message1 = "PlayerFirstName is----" + SelectedTime.PlayerFirstName + "----PlayerLastNameis----" +
                       SelectedTime.PlayerLastName + "-----Phone is--" + SelectedTime.Phone;


        }

        public void OnPostSecondAction()
        {
            TeeTime selectedTime1 = new TeeTime();

            DateTime date3 = DateTime.Parse(Date);
            DateTime time = DateTime.Parse(Time);

            selectedTime1.PlayerFirstName = PlayerFirstName;
            selectedTime1.PlayerLastName = PlayerLastName;
            selectedTime1.Phone = Phone;

            CBGS RequestDirector = new CBGS();

            bool Confirmation;


           
                Confirmation = RequestDirector.ModifyTeeTime(date3,time,selectedTime1);
                if (Confirmation)
                    Message2 = "Tee Time Modified";
                else
                    Message2 = "Tee Time Not Modified";

           






        }
    }

}
