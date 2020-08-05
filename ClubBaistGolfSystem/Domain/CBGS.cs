using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.TechnicalServices;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.Domain
{
    class CBGS
    {
        public List<TeeTime> ViewTeeSheet(DateTime date)
        {
            List<TeeTime> RequestedTeeSheet;
            TeeSheet TeeSheetManager = new TeeSheet();
            RequestedTeeSheet = TeeSheetManager.GetTeeSheet(date);
            return RequestedTeeSheet;

        }

        public bool BookTeeTime(TeeTime selectedTeeTime)
        {
            bool Confirmation;
            TeeSheet TeeSheetManager = new TeeSheet();
            Confirmation = TeeSheetManager.AddTeeTime(selectedTeeTime);
            return Confirmation;
        }


        public List<StandingTeeTime> ViewStandingTeeTime(DateTime date1)
        {
            List<StandingTeeTime> StandingTeeTimes;
            StandingTeeTimeRequests StandingTeeTimeManager = new StandingTeeTimeRequests();
            StandingTeeTimes = StandingTeeTimeManager.GetStandingTeeTime(date1);
            return StandingTeeTimes;
        }

        public bool SubmitStandingTeeTime(StandingTeeTime RequestedStandingTeeTime)
        {
            bool Confirmation;
            StandingTeeTimeRequests StandingTeeTimeManager = new StandingTeeTimeRequests();
            Confirmation = StandingTeeTimeManager.AddStandingTeeTime(RequestedStandingTeeTime);
            return Confirmation;
        }

        public StandingTeeTime FindStandingTeeTime(string MemberNumber)
        {

            StandingTeeTime SearchedStandingTeeTime;
            StandingTeeTimeRequests StandingTeeTimeManager = new StandingTeeTimeRequests();
            SearchedStandingTeeTime = StandingTeeTimeManager.SearchStandingTeeTime(MemberNumber);
            return SearchedStandingTeeTime;


        }

        public bool RemoveStandingTeeTimeRequest(string MemberNumber)
        {
            bool Confirmation2;
            StandingTeeTimeRequests StandingTeeTimeManager = new StandingTeeTimeRequests();
            Confirmation2 = StandingTeeTimeManager.DeleteStandingTeeTimeRequest(MemberNumber);
            return Confirmation2;
        }


        public TeeTime ViewTeeTime(DateTime date3, DateTime time)
        {
            TeeTime SelectedTime = new TeeTime();
            TeeSheet TeeSheetManager = new TeeSheet();
            SelectedTime = TeeSheetManager.GetTeeTime(date3, time);
            return SelectedTime;
        }

        public bool ModifyTeeTime(DateTime date3, DateTime time, TeeTime SelectedTime)
        {
            bool Confirmation;
            TeeSheet TeeSheetManager = new TeeSheet();
            Confirmation = TeeSheetManager.UpdateTeeTime(date3, time, SelectedTime);
            return Confirmation;
        }


        public bool AddsMembershipApplication(MembershipApplication ApplicationInformation)
        {
            bool Confirmation;
            MembershipApplications MembershipApplicationManager = new MembershipApplications();
            Confirmation = MembershipApplicationManager.RecordsMembershipApplication(ApplicationInformation);
            return Confirmation;
        }

        public List<MembershipApplication> ViewApplications(string Status)
        {
            List<MembershipApplication> RequestedApplications;
            MembershipApplications MembershipApplicationManager = new MembershipApplications();
            RequestedApplications = MembershipApplicationManager.GetMembershipAplications(Status);
            return RequestedApplications;
        }

        public bool ModifyApplication(string MemberApplicationNumber, MembershipApplication newMembershipApplication)
        {
            bool Confirmation1;
            MembershipApplications MembershipApplicationManager = new MembershipApplications();
            Confirmation1 = MembershipApplicationManager.UpdateMembershipApplication(MemberApplicationNumber, newMembershipApplication);
            return Confirmation1;
        }

        public bool InsertMember(Member MemberDetails)
        {
            bool Confirmation;
            Members MemberManager = new Members();
            Confirmation = MemberManager.AddMember(MemberDetails);
            return Confirmation;
        }

        public bool InsertMemberAccount(MemberAccount AccountDetails)
        {
            bool Confirmation;
            MemberAccounts MemberAccountManager = new MemberAccounts();
            Confirmation = MemberAccountManager.AddMemberAccount(AccountDetails);
            return Confirmation;
        }

        public MemberAccount FindAccount(string MemberAccountNumber)
        {
            MemberAccount RequestedAccount;
            MemberAccounts MemberAccountManager = new MemberAccounts();
            RequestedAccount = MemberAccountManager.GetMemberAccount(MemberAccountNumber);
            return RequestedAccount;
        }

        public bool InsertPlayerScore(PlayerScore NewPlayerScore)
        {
            bool Confirmation;
            PlayerScores PlayerScoreManager = new PlayerScores();
            Confirmation = PlayerScoreManager.AddPlayerScore(NewPlayerScore);
            return Confirmation;
        }

        public double ViewHandicapFactor(string MemberNumber)
        {
            double HandicapFactor;
            PlayerScores PlayerScoreManager = new PlayerScores();
            HandicapFactor = PlayerScoreManager.GetHandicapFactor(MemberNumber);
            return HandicapFactor;
        }
    }
}
