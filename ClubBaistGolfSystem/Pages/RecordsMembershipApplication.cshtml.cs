using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.Domain;
using System.ComponentModel.DataAnnotations;

namespace ClubBaistGolfSystem.Pages
{
    public class RecordsMembershipApplicationModel : PageModel
    {
        [BindProperty]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        public string Address { get; set; }

        [BindProperty]
        [Required]
        public string PostalCode { get; set; }

        [BindProperty]
        [Required]
        public string Phone { get; set; }

        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string DateOfBirth { get; set; }

        [BindProperty]
        public string Occupation { get; set; }

        [BindProperty]
        public string CompanyName { get; set; }

        [BindProperty]
        public string CompanyAddress { get; set; }

        [BindProperty]
        public string CompanyPostalCode { get; set; }

        [BindProperty]
        public string CompanyPhone { get; set; }

        [BindProperty]
        [Required]
        public string ShareholderName { get; set; }

        [BindProperty]
        [Required]
        public string Date { get; set; }

        [BindProperty]
        [Required]
        public string Status { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }


        public void OnPost()
        {
            MembershipApplication ApplicationInformation = new MembershipApplication();
            ApplicationInformation.FirstName = FirstName;
            ApplicationInformation.LastName = LastName;
            ApplicationInformation.Address = Address;
            ApplicationInformation.PostalCode = PostalCode;
            ApplicationInformation.Phone= Phone;
            ApplicationInformation.Email= Email;
            ApplicationInformation.DateOfBirth= DateOfBirth;
            ApplicationInformation.Occupation = Occupation;
            ApplicationInformation.CompanyName = CompanyName;
            ApplicationInformation.CompanyAddress = CompanyAddress;
            ApplicationInformation.CompanyPostalCode= CompanyPostalCode;
            ApplicationInformation.CompanyPhone= CompanyPhone;
            ApplicationInformation.ShareholderName = ShareholderName;
            ApplicationInformation.Date = Date;
            ApplicationInformation.Status = Status;       

            CBGS RequestDirector = new CBGS();

            bool Confirmation;


            if (ModelState.IsValid)
            {
                Confirmation = RequestDirector.AddsMembershipApplication(ApplicationInformation);

                if (Confirmation)
                    Message = "Membership Application Recorded";
            }

            else
                Message = "Membership Application Not Recorded";
           






        }
    }
}
