using System;
using System.Collections.Generic;

namespace BOM.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public int MembershipTypeID { get; set; }
        public int OrganizationID { get; set; }
        public int StatusID { get; set; }
        public List<int> PersonRoles { get; set; }
        public List<Location> OrgLocations { get; set; }

        public bool FoundInDB { get; set; }

        //  CANDIDATE/HOLDER INFORMATION

        public string CertificateName { get; set; }
        public string CareerStartDate { get; set; }
        public int OrganizationTypeID { get; set; }
        public int OrganizationRoleID { get; set; }
        public int EducationLevelID { get; set; }
        public int EducationMajorID { get; set; }
        public int YearsBusExpID { get; set; }
        public int YearsITExpID { get; set; }
        public int RetirementStatusID { get; set; }

        //  APPLICATION IMPORT INFORMATION

        public string EmailAddress { get; set; }
        public byte EmailICCP { get; set; }
        public byte EmailComms { get; set; }
        public int MailingCBIP { get; set; }
        public int MailingTDWI { get; set; }
        public int MailingICCP { get; set; }
        public int MailingRelated { get; set; }
        public string OrganizationName { get; set; }
        public string JobPosition { get; set; }
        public string JobPositionDesc { get; set; }
        public string EmploymentDate { get; set; }
        public byte AppliedForCBIPCert { get; set; }
        public byte AppliedforICCPCert { get; set; }
        public byte PassedICCPExam { get; set; }
        public string DesignationDate { get; set; }
        public byte DisabilityCheck { get; set; }
        public int TDWIMembershipPref { get; set; }

        //  SCHOOL ACTIVITIES INFORMATION

        public int MemberID { get; set; }
        public string CertificationType { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityName { get; set; }
        public int ActivityHours { get; set; }
        public string Sponsor { get; set; }
        public int ContEducationType { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1}  ", CustomerID, OrganizationName);
        }
    }
}