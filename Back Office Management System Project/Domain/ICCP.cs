using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOM.TechnicalServices;
using BOM.Domain;



namespace BOM.Domain
{
    public static class ICCP
    {
        public static bool AddOrganization(Organization NewCustomer)
        {
            bool Confirmation;
            Organizations OrganizationManager = new Organizations();
            Confirmation = OrganizationManager.CreateOrganization(NewCustomer);
            return Confirmation;
        }

        public static List<Location> ViewCountries()
        {
            List<Location> SelectedCountries;
            Organizations OrganizationManager = new Organizations();
            SelectedCountries = OrganizationManager.GetCountries();
            return SelectedCountries;
        }

        public static List<OrganizationTypeDetails> ViewOrganizationType()
        {
            List<OrganizationTypeDetails> SelectedOrganizationTypes;
            Organizations OrganizationManager = new Organizations();
            SelectedOrganizationTypes = OrganizationManager.GetOrganizationType();
            return SelectedOrganizationTypes;
        }

        public static Organization SearchOrganization(int CustomerID)
        {
            Organizations OrganizationManager = new Organizations();
            Organization ActiveOrganization;
            ActiveOrganization = OrganizationManager.LookupOrganization(CustomerID);
            return ActiveOrganization;
        }

        public static List<Location> LookupOrganizationLocation(int CustomerID, int OrgLocationID)
        {
            Organizations OrganizationManager = new Organizations();
            return OrganizationManager.LookupOrganizationLocation(CustomerID, OrgLocationID);
        }

        public static Location LookupOrganizationByLocation(int CustomerID, int OrgLocationID)
        {
            Organizations OrganizationManager = new Organizations();
            return OrganizationManager.LookupOrganizationByLocation(CustomerID, OrgLocationID);
        }

        public static Organization LookupOrganizationContact(int OrganizationID, int OrgContactID)
        {
            Organizations OrganizationManager = new Organizations();
            return OrganizationManager.LookupOrganizationContact(OrganizationID, OrgContactID);
        }

        public static List<Organization> ViewOrganizations()
        {
            List<Organization> ActiveOrganizations;
            Organizations OrganizationManager = new Organizations();
            ActiveOrganizations= OrganizationManager.GetOrganizations();
            return ActiveOrganizations;
        }
        public static bool ModifyOrganization(Organization ActiveCustomer)
        {
            bool Confirmation;
            Organizations OrganizationManager = new Organizations();
            Confirmation=OrganizationManager.UpdateOrganization(ActiveCustomer);
            return Confirmation;
        }
       

    }

}
