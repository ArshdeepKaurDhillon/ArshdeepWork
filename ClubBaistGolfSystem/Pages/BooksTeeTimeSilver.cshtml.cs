using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using ClubBaistGolfSystem.Domain;


namespace ClubBaistGolfSystem.Pages
{
    public class BooksTeeTimeSilverModel : PageModel
    {
        private bool validTime;
        public string Message { get; set; }
        public List<TeeTime> RequestedTeeSheet { get; } = new List<TeeTime>();

        [BindProperty]
        [Required]
        [Range(typeof(DateTime), "4/1/2020", "9/30/2020")]
        public string Date { get; set; }

        [BindProperty]
        [Required]
        public string Time
        {
            get
            {
                return Time;
            }
            set
            {
                int hours = int.Parse(value.Substring(0, 2));
                int mins = int.Parse(value.Substring(3));
                validTime = hours > 17 && mins > 30 || hours < 15 && mins < 00;
                if (validTime)
                    Time = value;
            }
        }

        [BindProperty]
        public string NumberOfCarts { get; set; }

        [BindProperty]
        [Required]
        public string NumberOfPlayers { get; set; }

        [BindProperty]
        [Required]
        public string PlayerFirstName { get; set; }

        [BindProperty]
        [Required]
        public string PlayerLastName { get; set; }

        [BindProperty]
        [Required]
        public string Phone{ get; set; }

        public void OnGet()
        {

        }
        public void OnPostFirstAction()
        {

            CBGS RequestDirector = new CBGS();

            DateTime date = DateTime.Parse(Date);
            RequestedTeeSheet.AddRange(RequestDirector.ViewTeeSheet(date));
        }
        public void OnPostSecondAction()
        {
            TeeTime selectedTeeTime = new TeeTime();
            selectedTeeTime.Date = Date;
            selectedTeeTime.Time = Time;
            selectedTeeTime.NumberOfCarts = NumberOfCarts;
            selectedTeeTime.NumberOfPlayers = NumberOfPlayers;
            selectedTeeTime.PlayerFirstName = PlayerFirstName;
            selectedTeeTime.PlayerLastName = PlayerLastName;
            selectedTeeTime.Phone = Phone;

            CBGS RequestDirector = new CBGS();

            bool Confirmation;

           
            if (ModelState.IsValid)                        
            {
                Confirmation = RequestDirector.BookTeeTime(selectedTeeTime);
                if (validTime)
                    Message = "Tee Time For Silver Level Player Booked";
                else
                    Message = "Not Valid Time for this membership level";
            }

            else
            {
                Message = "Tee Time For Silver Level Player Not Booked";
            }
        }
    }
}