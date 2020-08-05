using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOM.TechnicalServices;
using BOM.Domain;



namespace BOM.Domain
{
    public class BOM
    {
     
        public bool AddOrganization(Organization NewCustomer)
        {
            bool Confirmation;
            Organizations OrganizationManager = new Organizations();
            Confirmation = OrganizationManager.CreateOrganization(NewCustomer);
            return Confirmation;
        }

        public List<Location> ViewCountries()
        {
            List<Location> SelectedCountries;
            Organizations OrganizationManager = new Organizations();
            SelectedCountries = OrganizationManager.GetCountries();
            return SelectedCountries;
        }

        public List<OrganizationTypeDetails> ViewOrganizationType()
        {
            List<OrganizationTypeDetails> SelectedOrganizationTypes;
            Organizations OrganizationManager = new Organizations();
            SelectedOrganizationTypes = OrganizationManager.GetOrganizationType();
            return SelectedOrganizationTypes;
        }

        public Organization LookupOrganization(int CustomerID)
        {
            Organizations OrganizationManager = new Organizations();
            Organization ActiveOrganization;
            ActiveOrganization = OrganizationManager.LookupOrganization(CustomerID);
            return ActiveOrganization;
        }

        public List<Location> LookupOrganizationLocation(int CustomerID, int OrgLocationID)
        {
            Organizations OrganizationManager = new Organizations();
            return OrganizationManager.LookupOrganizationLocation(CustomerID, OrgLocationID);
        }

        public static Organization LookupOrganizationContact(int OrganizationID, int OrgContactID)
        {
            Organizations OrganizationManager = new Organizations();
            return OrganizationManager.LookupOrganizationContact(OrganizationID, OrgContactID);
        }


    }
}
