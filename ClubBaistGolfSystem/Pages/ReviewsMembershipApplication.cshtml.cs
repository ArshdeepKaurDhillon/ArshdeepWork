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
    public class ReviewsMembershipApplicationModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Status { get; set; }
        [BindProperty]
        [Required]
        public string MemberApplicationNumber { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string MemberType { get; set; }       
        [BindProperty]
        public double Balance { get; set; }     
        [BindProperty]
        public double Amount { get; set; }
        [BindProperty]
        public string  ActivityDate { get; set; }
        [BindProperty]
        public string  PostedDate { get; set; }
        
        [BindProperty]
        [Required]
        public string Description { get; set; }

        public string Message1 { get; set; }
        public string Message2 { get; set; }
      
        public List<MembershipApplication> RequestedApplications { get; set; } = new List<MembershipApplication>();

        List<MemberAccountEntry> newMemberAccountEntries { get; set; } = new List<MemberAccountEntry>();

        public void OnGet()
        {
        }

        public void OnPostFirstAction()
        {
            CBGS RequestDirector = new CBGS();
            RequestedApplications = RequestDirector.ViewApplications(Status);
        }

        public void OnPostSecondAction()
        {
            bool Confirmation1;
            if (ModelState.IsValid)
            {
            MembershipApplication newMembershipApplication = new MembershipApplication();
            newMembershipApplication.MemberApplicationNumber = MemberApplicationNumber;
            newMembershipApplication.FirstName = FirstName;
            newMembershipApplication.LastName = LastName;
            newMembershipApplication.Address = Address;
            newMembershipApplication.PostalCode = PostalCode;
            newMembershipApplication.Phone = Phone;
            newMembershipApplication.Email = Email;
            newMembershipApplication.Status = Status;

            CBGS RequestDirector = new CBGS();
            RequestDirector.ModifyApplication(MemberApplicationNumber, newMembershipApplication);

            Member MemberDetails = new Member();
            MemberDetails.MemberNumber = MemberApplicationNumber;
            MemberDetails.FirstName = FirstName;
            MemberDetails.LastName = LastName;
            MemberDetails.Address = Address;
            MemberDetails.PostalCode = PostalCode;
            MemberDetails.Phone = Phone;
            MemberDetails.Email = Email;
            MemberDetails.MemberType = MemberType;

            RequestDirector.InsertMember(MemberDetails);

            MemberAccount NewMemberAccount = new MemberAccount();
            NewMemberAccount.MemberNumber = MemberApplicationNumber;
            NewMemberAccount.Balance = Balance;
            NewMemberAccount.Entries = new List<MemberAccountEntry>();

            List<MemberAccountEntry> Entries= new List<MemberAccountEntry>();
            MemberAccountEntry Entry = new MemberAccountEntry();
            Entry.MemberNumber = MemberApplicationNumber;
            Entry.Amount = Amount;
            Entry.ActivityDate = ActivityDate;
            Entry.PostedDate = PostedDate;
            Entry.Description = Description;
            Entries.Add(Entry);

            NewMemberAccount.Entries.Add(Entry);
            
            //NewMemberAccount.newMemberAccountEntries.Add(Entry);
            
            Confirmation1= RequestDirector.InsertMemberAccount(NewMemberAccount);

            if (Confirmation1)
                Message2 = "Member Added";

            }
            else
                Message2 = "Member Not Added";
        
        }
    }
}
