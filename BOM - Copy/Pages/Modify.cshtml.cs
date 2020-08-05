using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BOM.Domain;
using BOM.TechnicalServices;
using System.ComponentModel.DataAnnotations;

namespace BOM.Pages
{
    public class ModifyModel : PageModel
    {
        [BindProperty]
        public int CustomerID { get; set; }

        [BindProperty]
        public string OrganizationLookupName { get; set; }

        [BindProperty]
        public string CountryName { get; set; }

        [BindProperty]
        public string CountryCode { get; set; }

        [BindProperty]
        public string RegionCode { get; set; }

        [BindProperty]
        public string RegionName { get; set; }

        [BindProperty]
        public int OrgType { get; set; }

        /***************************************************************************
         * Organization Information
        */

        [BindProperty]
        public int OrganizationID { get; set; }

        [BindProperty]
        [Required]
        public string OrganizationName { get; set; }

        [BindProperty]
        public string OrganizationType { get; set; }

        [BindProperty]
        public string OtherOrgType { get; set; }

        public List<OrganizationTypeDetails> OrganizationTypeCollection { get; set; } = new List<OrganizationTypeDetails>();


        [BindProperty]
        public int OrganizationTypeID { get; set; }


        [BindProperty]
        public string PostalCode { get; set; }

        /***************************************************************************
         * Contact Information
         */

        [BindProperty]
        public string PrimaryContact { get; set; }

        [BindProperty]
        public string OrganizationRole { get; set; }


        [BindProperty]
        public string OtherOrgRole { get; set; }

        [BindProperty]
        public int OrganizationRoleID { get; set; }


        public List<OrganizationRoleDetails> OrganizationRoleCollection { get; set; } = new List<OrganizationRoleDetails>();


        [BindProperty]
        public string EmailAddress { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }


        /***************************************************************************
         * Shipping Address
         */

        [BindProperty]
        public string ShippingStreetAddress { get; set; }

        [BindProperty]
        public string ShippingUnitNumber { get; set; }

        [BindProperty]
        public string ShippingCountryName { get; set; }

        [BindProperty]
        public string ShippingCountryCode { get; set; }


        public List<Location> CountryCollection { get; set; } = new List<Location>();


        public List<Location> RegionCollection { get; set; } = new List<Location>();


        [BindProperty]
        public string ShippingRegionCode { get; set; }

        [BindProperty]
        public string ShippingRegionName { get; set; }

        [BindProperty]
        public string ShippingCity { get; set; }

        [BindProperty]
        public string ShippingPostalCode { get; set; }


        /***************************************************************************
         * Billing Address
         */

        [BindProperty]
        public string BillingStreetAddress { get; set; }

        [BindProperty]
        public string BillingUnitNumber { get; set; }

        [BindProperty]
        public string BillingCountryName { get; set; }

        [BindProperty]
        public string BillingCountryCode { get; set; }

        [BindProperty]
        public string BillingRegionCode { get; set; }

        [BindProperty]
        public string BillingRegionName { get; set; }

        [BindProperty]
        public string BillingCity { get; set; }

        [BindProperty]
        public string BillingPostalCode { get; set; }


        /***************************************************************************
         * Properties
        */

        public int OrgLocationID { get; set; }

        public string Message { get; set; }
        public string Message1 { get; set; }

        public string LocationName { get; set; }
        public int OrgContactID { get; set; }

        [BindProperty]
        public List<Customer> ActiveCustomers { get; set; } = new List<Customer>();

        public List<Location> OrgLocations { get; set; }

        public List<Location> ShippingCountryNames { get; set; } = new List<Location>();

        public List<Location> BillingCountryNames { get; set; } = new List<Location>();

        public List<Location> CountryNames { get; set; } = new List<Location>();

        public List<Organization> ActiveOrganizations { get; set; } = new List<Organization>();

        [BindProperty]
        public string CountryNameSearch { get; set; }
        [BindProperty]
        public string RegionSearch { get; set; }
        [BindProperty]
        public string PostalCodeSearch { get; set; }

        public int OrgCustomerID { get; set; }

        public IEnumerable<Organization> displaydata { get; set; }

        public void OnGet()
        {
            ActiveOrganizations.AddRange(ICCP.ViewOrganizations());

            ShippingCountryNames.AddRange(ICCP.ViewCountries());

            BillingCountryNames.AddRange(ICCP.ViewCountries());

            CountryNames.AddRange(ICCP.ViewCountries());

            OrganizationTypeDetails organizationTypeDetails = new OrganizationTypeDetails();
            Organizations OrganizationManager = new Organizations();
            OrganizationTypeCollection = OrganizationManager.GetOrganizationType();
            organizationTypeDetails.OrganizationTypeID = OrganizationTypeID;
            organizationTypeDetails.OrganizationType = OrganizationType;
            OrganizationTypeCollection.Add(organizationTypeDetails);

            OrganizationRoleDetails organizationRoleDetails = new OrganizationRoleDetails();
            OrganizationRoleCollection = OrganizationManager.GetOrganizationRole();
            organizationRoleDetails.OrganizationRoleID = OrganizationRoleID;
            organizationRoleDetails.OrganizationRole = OrganizationRole;
            OrganizationRoleCollection.Add(organizationRoleDetails);

            Location RegionDetails = new Location();
            RegionCollection = OrganizationManager.GetRegions();
            RegionDetails.RegionCode = ShippingRegionCode;
            RegionDetails.RegionName = ShippingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = BillingRegionCode;
            RegionDetails.RegionName = BillingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = RegionCode;
            RegionDetails.RegionName = RegionName;
            RegionCollection.Add(RegionDetails);

            Location CountryDetails = new Location();
            CountryCollection = OrganizationManager.GetCountries();
            CountryDetails.CountryCode = ShippingCountryCode;
            CountryDetails.CountryName = ShippingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = BillingCountryCode;
            CountryDetails.CountryName = BillingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = CountryCode;
            CountryDetails.CountryName = CountryName;
            CountryCollection.Add(CountryDetails);

        }

        public void OnPostOrganizationLookup()
        {
            ActiveOrganizations.AddRange(ICCP.ViewOrganizations());

            ShippingCountryNames.AddRange(ICCP.ViewCountries());

            BillingCountryNames.AddRange(ICCP.ViewCountries());

            CountryNames.AddRange(ICCP.ViewCountries());

            OrganizationTypeDetails organizationTypeDetails = new OrganizationTypeDetails();
            Organizations OrganizationManager = new Organizations();
            OrganizationTypeCollection = OrganizationManager.GetOrganizationType();
            organizationTypeDetails.OrganizationTypeID = OrganizationTypeID;
            organizationTypeDetails.OrganizationType = OrganizationType;
            OrganizationTypeCollection.Add(organizationTypeDetails);

            OrganizationRoleDetails organizationRoleDetails = new OrganizationRoleDetails();
            OrganizationRoleCollection = OrganizationManager.GetOrganizationRole();
            organizationRoleDetails.OrganizationRoleID = OrganizationRoleID;
            organizationRoleDetails.OrganizationRole = OrganizationRole;
            OrganizationRoleCollection.Add(organizationRoleDetails);

            Location RegionDetails = new Location();
            RegionCollection = OrganizationManager.GetRegions();
            RegionDetails.RegionCode = ShippingRegionCode;
            RegionDetails.RegionName = ShippingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = BillingRegionCode;
            RegionDetails.RegionName = BillingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = RegionCode;
            RegionDetails.RegionName = RegionName;
            RegionCollection.Add(RegionDetails);

            Location CountryDetails = new Location();
            CountryCollection = OrganizationManager.GetCountries();
            CountryDetails.CountryCode = ShippingCountryCode;
            CountryDetails.CountryName = ShippingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = BillingCountryCode;
            CountryDetails.CountryName = BillingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = CountryCode;
            CountryDetails.CountryName = CountryName;
            CountryCollection.Add(CountryDetails);

            //Organizations OrganizationManager = new Organizations();

            int organizationID = OrganizationManager.GetOrganizationID(OrganizationLookupName);
            int locationID = OrganizationManager.GetOrganizationLocationID(organizationID);
            Organization ActiveOrganization = new Organization();

            ActiveOrganization = ICCP.SearchOrganization(organizationID);
            OrganizationName = ActiveOrganization.OrganizationName;
            //OrganizationID = ActiveOrganization.OrganizationID;
            OrganizationType = Convert.ToString(ActiveOrganization.OrgTypeID);
            OtherOrgType = ActiveOrganization.OtherOrgType;

           // int locationID = OrganizationManager.GetOrganizationLocationID(organizationID);

            List<Location> activeLocations = new List<Location>();
            activeLocations = ICCP.LookupOrganizationLocation(organizationID, locationID);

            if (activeLocations.Count >= 0)
                foreach (var activeLocation in activeLocations)
                {
                    switch (activeLocation.AddressTypeID)
                    {
                        default:

                            BillingStreetAddress = activeLocation.Address;
                            BillingUnitNumber = activeLocation.Address2;
                            BillingRegionName = activeLocation.RegionName;
                            BillingCity = activeLocation.City;
                            BillingCountryName = activeLocation.CountryName;
                            BillingPostalCode = activeLocation.PostalCode;

                            break;

                        case 5:
                            ShippingStreetAddress = activeLocation.Address;
                            ShippingUnitNumber = activeLocation.Address2;
                            ShippingRegionName = activeLocation.RegionName;
                            ShippingCity = activeLocation.City;
                            ShippingCountryName = activeLocation.CountryName;
                            ShippingPostalCode = activeLocation.PostalCode;
                            break;

                    }

                }



            Organization ActiveContact = new Organization();
            int OrganizationContactID = OrganizationManager.GetOrganizationContactID(organizationID);
            ActiveContact = OrganizationManager.LookupOrganizationContact(organizationID, OrganizationContactID);
            OtherOrgRole = ActiveContact.OtherOrgRole;
            PrimaryContact = ActiveContact.PrimaryContact;
            EmailAddress = ActiveContact.EmailAddress;
            PhoneNumber = ActiveContact.PhoneNumber;

        }

        public void OnPostSearchByID()
        {
            ActiveOrganizations.AddRange(ICCP.ViewOrganizations());

            ShippingCountryNames.AddRange(ICCP.ViewCountries());

            BillingCountryNames.AddRange(ICCP.ViewCountries());

            CountryNames.AddRange(ICCP.ViewCountries());

            OrganizationTypeDetails organizationTypeDetails = new OrganizationTypeDetails();
            Organizations OrganizationManager = new Organizations();
            OrganizationTypeCollection = OrganizationManager.GetOrganizationType();
            organizationTypeDetails.OrganizationTypeID = OrganizationTypeID;
            organizationTypeDetails.OrganizationType = OrganizationType;
            OrganizationTypeCollection.Add(organizationTypeDetails);

            OrganizationRoleDetails organizationRoleDetails = new OrganizationRoleDetails();
            OrganizationRoleCollection = OrganizationManager.GetOrganizationRole();
            organizationRoleDetails.OrganizationRoleID = OrganizationRoleID;
            organizationRoleDetails.OrganizationRole = OrganizationRole;
            OrganizationRoleCollection.Add(organizationRoleDetails);

            Location RegionDetails = new Location();
            RegionCollection = OrganizationManager.GetRegions();
            RegionDetails.RegionCode = ShippingRegionCode;
            RegionDetails.RegionName = ShippingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = BillingRegionCode;
            RegionDetails.RegionName = BillingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = RegionCode;
            RegionDetails.RegionName = RegionName;
            RegionCollection.Add(RegionDetails);

            Location CountryDetails = new Location();
            CountryCollection = OrganizationManager.GetCountries();
            CountryDetails.CountryCode = ShippingCountryCode;
            CountryDetails.CountryName = ShippingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = BillingCountryCode;
            CountryDetails.CountryName = BillingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = CountryCode;
            CountryDetails.CountryName = CountryName;
            CountryCollection.Add(CountryDetails);



           // Organizations OrganizationManager = new Organizations();

            Organization ActiveOrganization = new Organization();
            ActiveOrganization = ICCP.SearchOrganization(CustomerID);
            OrganizationName = ActiveOrganization.OrganizationName;
            //OrganizationType = Convert.ToString(ActiveOrganization.OrgTypeID);
            OrganizationType = ActiveOrganization.OrganizationType;
            //OrgA =  ActiveOrganization.OrgTypeID;
            OtherOrgType = ActiveOrganization.OtherOrgType;
            OrganizationID = ActiveOrganization.OrganizationID;
            int locationID = OrganizationManager.GetOrganizationLocationID(CustomerID);

            List<Location> activeLocations = new List<Location>();
            activeLocations = ICCP.LookupOrganizationLocation(CustomerID, locationID);

            //foreach (var activeLocation in activeLocations)
            //{
            //    BillingStreetAddress = activeLocation.Address;
            //    BillingUnitNumber = activeLocation.Address2;
            //    BillingRegionName = activeLocation.RegionName;
            //    BillingCity = activeLocation.City;
            //    BillingCountryName = activeLocation.CountryName;
            //    BillingPostalCode = activeLocation.PostalCode;
            //}
             
            if(activeLocations.Count>=0)
            foreach (var activeLocation in activeLocations)
            {
                    switch(activeLocation.AddressTypeID)
                    {
                        default:
                            
                            BillingStreetAddress = activeLocation.Address;
                            BillingUnitNumber = activeLocation.Address2;
                            BillingRegionName = activeLocation.RegionName;
                            BillingCity = activeLocation.City;
                            BillingCountryName = activeLocation.CountryName;
                            BillingPostalCode = activeLocation.PostalCode;

                            break;

                        case 5:
                            ShippingStreetAddress = activeLocation.Address;
                            ShippingUnitNumber = activeLocation.Address2;
                            ShippingRegionName = activeLocation.RegionName;
                            ShippingCity = activeLocation.City;
                            ShippingCountryName = activeLocation.CountryName;
                            ShippingPostalCode = activeLocation.PostalCode;
                            break;

                    }
                
            }
           

           
            Organization ActiveContact = new Organization();
            int OrganizationContactID = OrganizationManager.GetOrganizationContactID(CustomerID);
            ActiveContact = OrganizationManager.LookupOrganizationContact(CustomerID, OrganizationContactID);
            OtherOrgRole = ActiveContact.OtherOrgRole;
            PrimaryContact = ActiveContact.PrimaryContact;
            EmailAddress = ActiveContact.EmailAddress;
            PhoneNumber = ActiveContact.PhoneNumber;
        }

        public void OnPostOrganizationForm()
        {
            ActiveOrganizations.AddRange(ICCP.ViewOrganizations());

            ShippingCountryNames.AddRange(ICCP.ViewCountries());

            BillingCountryNames.AddRange(ICCP.ViewCountries());

            CountryNames.AddRange(ICCP.ViewCountries());

            OrganizationTypeDetails organizationTypeDetails = new OrganizationTypeDetails();
            Organizations OrganizationManager = new Organizations();
            OrganizationTypeCollection = OrganizationManager.GetOrganizationType();
            organizationTypeDetails.OrganizationTypeID = OrganizationTypeID;
            organizationTypeDetails.OrganizationType = OrganizationType;
            OrganizationTypeCollection.Add(organizationTypeDetails);

            OrganizationRoleDetails organizationRoleDetails = new OrganizationRoleDetails();
            OrganizationRoleCollection = OrganizationManager.GetOrganizationRole();
            organizationRoleDetails.OrganizationRoleID = OrganizationRoleID;
            organizationRoleDetails.OrganizationRole = OrganizationRole;
            OrganizationRoleCollection.Add(organizationRoleDetails);

            Location RegionDetails = new Location();
            RegionCollection = OrganizationManager.GetRegions();
            RegionDetails.RegionCode = ShippingRegionCode;
            RegionDetails.RegionName = ShippingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = BillingRegionCode;
            RegionDetails.RegionName = BillingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = RegionCode;
            RegionDetails.RegionName = RegionName;
            RegionCollection.Add(RegionDetails);

            Location CountryDetails = new Location();
            CountryCollection = OrganizationManager.GetCountries();
            CountryDetails.CountryCode = ShippingCountryCode;
            CountryDetails.CountryName = ShippingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = BillingCountryCode;
            CountryDetails.CountryName = BillingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = CountryCode;
            CountryDetails.CountryName = CountryName;
            CountryCollection.Add(CountryDetails);




            bool Confirmation;
            Organization newCustomer = new Organization();

            newCustomer.OrganizationName = OrganizationName;
            newCustomer.OrgTypeID = int.Parse(OrganizationType);
            newCustomer.OtherOrgType = OtherOrgType;
            newCustomer.OrgLocations = new List<Location>();

            newCustomer.CustomerID = CustomerID;

            List<Location> newLocations = new List<Location>();

            Location newLocation1 = new Location();
            newLocation1.OrgCustomerID = CustomerID;
            newLocation1.AddressTypeID = 4;
            newLocation1.Address = BillingStreetAddress;
            newLocation1.Address2 = BillingUnitNumber;
            newLocation1.City = BillingCity;
            newLocation1.CountryName = BillingCountryName;
            newLocation1.PostalCode = BillingPostalCode;
            newLocation1.RegionName = BillingRegionName;
            newLocation1.OrgLocationName = BillingUnitNumber + '(' + BillingCity + ',' + BillingCountryName + ')';

            newLocations.Add(newLocation1);
            newCustomer.OrgLocations.Add(newLocation1);

            Location newLocation2 = new Location();
            newLocation2.OrgLocationID = OrgLocationID;

            newLocation2.OrgCustomerID = CustomerID;
            newLocation2.AddressTypeID = 5;
            newLocation2.Address = ShippingStreetAddress;
            newLocation2.Address2 = ShippingUnitNumber;
            newLocation2.City = ShippingCity;
            newLocation2.CountryName = ShippingCountryName;
            newLocation2.PostalCode = ShippingPostalCode;
            newLocation2.RegionName = ShippingRegionName;
            newLocation2.OrgLocationName = ShippingUnitNumber + '(' + ShippingCity + ',' + ShippingCountryName + ')';

            newLocations.Add(newLocation2);
            newCustomer.OrgLocations.Add(newLocation2);
            newLocation2.OrgLocationID = OrgLocationID;


            newCustomer.CustomerID = CustomerID;
            newCustomer.OrgCustomerID = CustomerID;
            newCustomer.PrimaryContact = PrimaryContact;
            newCustomer.OrganizationRoleID = int.Parse(OrganizationRole);
            newCustomer.OtherOrgRole = OtherOrgRole;
            newCustomer.EmailAddress = EmailAddress;
            newCustomer.PhoneNumber = PhoneNumber;


            if (ModelState.IsValid)
            {
                Confirmation = ICCP.AddOrganization(newCustomer);
                if (Confirmation)
                    Message = "Organization Added Successfully";


            }

            else
            {
                Message = "Organization Not Added";

            }

        }


        public void OnPostSearchByLocation()
        {
            Organizations OrgnaizationManager = new Organizations();
            ActiveCustomers.AddRange(OrgnaizationManager.LookupOrganizationByValue(CountryNameSearch, RegionSearch, PostalCodeSearch));
        }



        public void OnPostModify()
        {
            ActiveOrganizations.AddRange(ICCP.ViewOrganizations());

            ShippingCountryNames.AddRange(ICCP.ViewCountries());

            BillingCountryNames.AddRange(ICCP.ViewCountries());

            CountryNames.AddRange(ICCP.ViewCountries());

            OrganizationTypeDetails organizationTypeDetails = new OrganizationTypeDetails();
            Organizations OrganizationManager = new Organizations();
            OrganizationTypeCollection = OrganizationManager.GetOrganizationType();
            organizationTypeDetails.OrganizationTypeID = OrganizationTypeID;
            organizationTypeDetails.OrganizationType = OrganizationType;
            OrganizationTypeCollection.Add(organizationTypeDetails);

            OrganizationRoleDetails organizationRoleDetails = new OrganizationRoleDetails();
            OrganizationRoleCollection = OrganizationManager.GetOrganizationRole();
            organizationRoleDetails.OrganizationRoleID = OrganizationRoleID;
            organizationRoleDetails.OrganizationRole = OrganizationRole;
            OrganizationRoleCollection.Add(organizationRoleDetails);

            Location RegionDetails = new Location();
            RegionCollection = OrganizationManager.GetRegions();
            RegionDetails.RegionCode = ShippingRegionCode;
            RegionDetails.RegionName = ShippingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = BillingRegionCode;
            RegionDetails.RegionName = BillingRegionName;
            RegionCollection.Add(RegionDetails);

            RegionDetails.RegionCode = RegionCode;
            RegionDetails.RegionName = RegionName;
            RegionCollection.Add(RegionDetails);

            Location CountryDetails = new Location();
            CountryCollection = OrganizationManager.GetCountries();
            CountryDetails.CountryCode = ShippingCountryCode;
            CountryDetails.CountryName = ShippingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = BillingCountryCode;
            CountryDetails.CountryName = BillingCountryName;
            CountryCollection.Add(CountryDetails);

            CountryDetails.CountryCode = CountryCode;
            CountryDetails.CountryName = CountryName;
            CountryCollection.Add(CountryDetails);




            //Organizations OrganizationManager = new Organizations();

            bool Confirmation;
            Organization activeCustomer = new Organization();
            activeCustomer.CustomerID = CustomerID;
            activeCustomer.OrganizationName = OrganizationName;
            activeCustomer.OrgTypeID = int.Parse(OrganizationType);
            activeCustomer.OtherOrgType = OtherOrgType;
            activeCustomer.OrgLocations = new List<Location>();
            int OrgLocationID = OrganizationManager.GetOrganizationLocationID(CustomerID);

            //activeCustomer.OrgLocations[0].OrgLocationID = OrgLocationID;
            activeCustomer.CustomerID = CustomerID;
            List<Location> newLocations = new List<Location>();
            Location newLocation = new Location();
            newLocation.OrgLocationID = OrgLocationID;
            newLocations.Add(newLocation);
            activeCustomer.OrgLocations.Add(newLocation);

            activeCustomer.OrgLocations[0].OrgLocationID = OrgLocationID;

            int OrgContactID = OrganizationManager.GetOrganizationContactID(CustomerID);
            activeCustomer.OrgCustomerID = CustomerID;

            //activeCustomer.OrgLocations[0].OrgLocationID = OrgLocationID;
            activeCustomer.CustomerID = CustomerID;
            activeCustomer.OrgContactID = CustomerID;

            activeCustomer.OrganizationRoleID = int.Parse(OrganizationRole);
            activeCustomer.OtherOrgRole = OtherOrgRole;
            activeCustomer.PrimaryContact = PrimaryContact;
            activeCustomer.EmailAddress = EmailAddress;
            activeCustomer.PhoneNumber = PhoneNumber;

            activeCustomer.CustomerID = CustomerID;

            Location newLocation1 = new Location();
            
            newLocation1.OrgCustomerID = CustomerID;
            newLocation1.OrgLocationID = OrgLocationID;
            newLocation1.AddressTypeID = 4;
            newLocation1.Address = BillingStreetAddress;
            newLocation1.Address2 = BillingUnitNumber;
            newLocation1.City = BillingCity;
            newLocation1.CountryName = BillingCountryName;
            newLocation1.PostalCode = BillingPostalCode;
            newLocation1.RegionName = BillingRegionName;
            newLocation1.OrgLocationName = BillingUnitNumber + '(' + BillingCity + BillingCountryName + ')';
            newLocations.Add(newLocation1);
            activeCustomer.OrgLocations.Add(newLocation1);
   
            
            
            Location newLocation2 = new Location();

           

            newLocation2.OrgCustomerID = CustomerID;
            newLocation2.OrgLocationID = OrgLocationID;
            newLocation2.AddressTypeID = 5;
            newLocation2.Address = ShippingStreetAddress;
            newLocation2.Address2 = ShippingUnitNumber;
            newLocation2.City = ShippingCity;
            newLocation2.CountryName = ShippingCountryName;
            newLocation2.PostalCode = ShippingPostalCode;
            newLocation2.RegionName = ShippingRegionName;
            newLocation2.OrgLocationName = ShippingUnitNumber + '(' + ShippingCity + ShippingCountryName + ')';

            newLocations.Add(newLocation2);
            activeCustomer.OrgLocations.Add(newLocation2);
            newLocation2.OrgLocationID = OrgLocationID;

            Confirmation = OrganizationManager.UpdateOrganization(activeCustomer);

            if (Confirmation)
            {
                Message = "Changes have been made successfully";
            }

            else
            {
                Message = "Changes have not been made";
            }

        }
 
    }
}
