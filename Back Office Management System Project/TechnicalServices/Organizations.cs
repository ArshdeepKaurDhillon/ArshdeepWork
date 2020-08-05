using BOM.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
#pragma warning disable CS0436 // Type conflicts with imported type

namespace BOM.TechnicalServices
{
    public class Organizations
    {
        // Set the database connection string
        private readonly string connectionString = @"Persist Security Info=false; Integrated Security=true;Database=BOM; Server=(localdb)\MSSQLLocalDB";

        // Create a transaction object to handle multiple requests at once
        private SqlTransaction TRNS;

        //internal bool CreateOrganization(Organization newCustomer)
        //{
        //    try
        //    {
        //        using (var CONN = new SqlConnection(connectionString))
        //        {

        //            CONN.Open();    // Open the connection to the database
        //            // Set the transaction to process multiple locations
        //            TRNS = CONN.BeginTransaction();
        //            // Call the stored procedure to create a new organization
        //            var CMD = new SqlCommand("spCreateOrganization", CONN, TRNS);
        //            CMD.CommandType = CommandType.StoredProcedure;
        //            // Set the parameters to send
        //            CMD.Parameters.Add("@OrganizationName", SqlDbType.VarChar).Value = newCustomer.OrganizationName;
        //            CMD.Parameters.Add("@OrganizationTypeID", SqlDbType.Int).Value = newCustomer.OrgTypeID;
        //            CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            // Execute the SQL transaction
        //            CMD.ExecuteNonQuery();
        //            // Save the returned CustomerID
        //            var customerID = Convert.ToInt32(CMD.Parameters["@CustomerID"].Value);
        //            ///////////////////////////////////////////////////////////////////////////////////
        //            // Create the Organization's Location Profile
        //            CMD = new SqlCommand("spAddOrganizationLocation", CONN, TRNS);
        //            CMD.CommandType = CommandType.StoredProcedure;
        //            CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
        //            CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].Address;
        //            CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].CountryName;
        //            CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].RegionName;
        //            CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].City;
        //            CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = newCustomer.OrgLocations[0].PreferredLocation;
        //            CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            CMD.ExecuteNonQuery();
        //            // Save the returned Organization Location ID
        //            var orgLocationID = Convert.ToInt32(CMD.Parameters["@OrgLocationID"].Value);
        //            ///////////////////////////////////////////////////////////////////////////////////
        //            // Save each Organization's location
        //            foreach (var location in newCustomer.OrgLocations)
        //            {
        //                CMD = new SqlCommand("spUpdateOrganizationLocation", CONN, TRNS);
        //                CMD.CommandType = CommandType.StoredProcedure;
        //                CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
        //                CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = orgLocationID;
        //                CMD.Parameters.Add("@AddressTypeID", SqlDbType.Int).Value = location.AddressTypeID;
        //                CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = location.Address;
        //                CMD.Parameters.Add("@Address2", SqlDbType.VarChar).Value = location.Address2;
        //                CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = location.City;
        //                CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = location.RegionName;
        //                CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = location.CountryName;
        //                CMD.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = location.PostalCode;
        //                CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = location.PreferredLocation;
        //                CMD.ExecuteNonQuery();
        //            }

        //            // Commit the database changes
        //            TRNS.Commit();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TRNS.Rollback();
        //        return false;
        //    }
        //}









        internal bool CreateOrganization(Organization newCustomer)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {

                    CONN.Open();    // Open the connection to the database
                    // Set the transaction to process multiple locations
                    TRNS = CONN.BeginTransaction();
                    // Call the stored procedure to create a new organization
                    var CMD = new SqlCommand("spCreateOrganization", CONN, TRNS);
                    CMD.CommandType = CommandType.StoredProcedure;
                    // Set the parameters to send
                    CMD.Parameters.Add("@OrganizationName", SqlDbType.VarChar).Value = newCustomer.OrganizationName;
                    CMD.Parameters.Add("@OrganizationTypeID", SqlDbType.Int).Value = newCustomer.OrgTypeID;
                    CMD.Parameters.Add("@OtherOrgType", SqlDbType.VarChar).Value = newCustomer.OtherOrgType;
                    CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    // Execute the SQL transaction
                    CMD.ExecuteNonQuery();
                    // Save the returned CustomerID
                    var customerID = Convert.ToInt32(CMD.Parameters["@CustomerID"].Value);
                    ///////////////////////////////////////////////////////////////////////////////////
                    // Create the Organization's Location Profile
                    CMD = new SqlCommand("spAddOrganizationLocation", CONN, TRNS);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].Address;
                    CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].CountryName;
                    CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].RegionName;
                    CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = newCustomer.OrgLocations[0].City;
                    CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = newCustomer.OrgLocations[0].PreferredLocation;
                    CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    CMD.ExecuteNonQuery();
                    // Save the returned Organization Location ID
                    var orgLocationID = Convert.ToInt32(CMD.Parameters["@OrgLocationID"].Value);
                    ///////////////////////////////////////////////////////////////////////////////////////
                    ////// Save each Organization's location
                    foreach (var location in newCustomer.OrgLocations)
                    {
                        CMD = new SqlCommand("spUpdateOrganizationLocation", CONN, TRNS);
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                        CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = orgLocationID;
                        CMD.Parameters.Add("@AddressTypeID", SqlDbType.Int).Value = location.AddressTypeID;
                        CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = location.Address;
                        CMD.Parameters.Add("@Address2", SqlDbType.VarChar).Value = location.Address2;
                        CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = location.City;
                        CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = location.RegionName;
                        CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = location.CountryName;
                        CMD.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = location.PostalCode;
                        CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = location.PreferredLocation;
                        CMD.ExecuteNonQuery();
                    }

                    CMD = new SqlCommand("spAddOrganizationContact", CONN, TRNS);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = orgLocationID;
                    CMD.Parameters.Add("@OrgCustomerID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@OrgPersonRoleID", SqlDbType.Int).Value = newCustomer.OrganizationRoleID;
                    CMD.Parameters.Add("@OtherOrgRole", SqlDbType.VarChar).Value = newCustomer.OtherOrgRole;
                    CMD.Parameters.Add("@PrimaryContact", SqlDbType.VarChar).Value = newCustomer.PrimaryContact;
                    CMD.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = newCustomer.EmailAddress;
                    CMD.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = newCustomer.PhoneNumber;
                    CMD.ExecuteNonQuery();

                    // Commit the database changes
                    TRNS.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                TRNS.Rollback();
                return false;
            }
        }

        internal bool UpdateOrganization(Organization activeCustomer)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {
                    CONN.Open();
                    TRNS = CONN.BeginTransaction();
                    // Call the stored procedure to update the organization
                    var CMD = new SqlCommand("spUpdateOrganization", CONN, TRNS);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@OrganizationID", SqlDbType.Int).Value = activeCustomer.CustomerID;
                    CMD.Parameters.Add("@OrganizationName", SqlDbType.VarChar).Value = activeCustomer.OrganizationName;
                    CMD.Parameters.Add("@OrganizationTypeID", SqlDbType.Int).Value = activeCustomer.OrgTypeID;
                    CMD.Parameters.Add("@OtherOrgType", SqlDbType.VarChar).Value = activeCustomer.OtherOrgType;

                    CMD.ExecuteNonQuery();
                    ///////////////////////////////////////////////////////////////////////////////////
                    //If an organization contact is set, save it otherwise remove it
                    if (activeCustomer.OrgContactID == 0)
                    {
                        CMD = new SqlCommand("spRemoveOrganizationContact", CONN, TRNS);
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = activeCustomer.CustomerID;
                        CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = activeCustomer.OrgLocations[0].OrgLocationID;
                        CMD.ExecuteNonQuery();
                    }
                    else
                    {
                        int result_count;
                        // Determine which stored procedure to run based on whether or not a contact already exists at the current location
                        using (CMD = new SqlCommand($"SELECT COUNT(*) FROM [Organization Contact] OC (NOLOCK) INNER JOIN [Organization Location] OL (NOLOCK) ON OL.OrgLocationID = OC.OrgLocationID WHERE OL.OrganizationID = {activeCustomer.CustomerID} AND OL.OrgLocationID = {activeCustomer.OrgLocations[0].OrgLocationID}", CONN, TRNS))
                            result_count = (int)CMD.ExecuteScalar();
                        CMD = result_count == 0
                            ? new SqlCommand("spAddOrganizationContact", CONN, TRNS)
                            : new SqlCommand("spUpdateOrganizationContact", CONN, TRNS);
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = activeCustomer.CustomerID;
                        CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = activeCustomer.OrgLocations[0].OrgLocationID;
                        CMD.Parameters.Add("@OrgCustomerID", SqlDbType.Int).Value = activeCustomer.OrgContactID;
                        CMD.Parameters.Add("@OrgPersonRoleID", SqlDbType.Int).Value = activeCustomer.OrganizationRoleID;
                        CMD.Parameters.Add("@OtherOrgRole", SqlDbType.VarChar).Value = activeCustomer.OtherOrgRole;
                        CMD.Parameters.Add("@PrimaryContact", SqlDbType.VarChar).Value = activeCustomer.PrimaryContact;

                        CMD.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = activeCustomer.EmailAddress;
                        CMD.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = activeCustomer.PhoneNumber;
                        CMD.ExecuteNonQuery();
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////
                    //////// Save the Organization's Location Information
                    foreach (var location in activeCustomer.OrgLocations)
                    {
                        // If the location is new, save it, otherwise update it
                        if (location.IsNewLocation)
                        {
                            CMD = new SqlCommand("spAddOrganizationLocation", CONN, TRNS);
                            CMD.CommandType = CommandType.StoredProcedure;
                            CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = activeCustomer.CustomerID;
                            CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = location.Address;
                            CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = location.CountryName;
                            CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = location.RegionName;
                            CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = location.City;
                            CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = location.PreferredLocation;
                            CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Direction = ParameterDirection.Output;
                            CMD.ExecuteNonQuery();
                            // Save the returned OrgLocationID
                            location.OrgLocationID = Convert.ToInt32(CMD.Parameters["@OrgLocationID"].Value);
                        }

                        CMD = new SqlCommand("spUpdateOrganizationLocation", CONN, TRNS);
                        CMD.CommandType = CommandType.StoredProcedure;
                        CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = activeCustomer.CustomerID;
                        CMD.Parameters.Add("@OrgLocationID", SqlDbType.VarChar).Value = location.OrgLocationID;
                        CMD.Parameters.Add("@AddressTypeID", SqlDbType.Int).Value = location.AddressTypeID;
                        CMD.Parameters.Add("@Address", SqlDbType.VarChar).Value = location.Address;
                        CMD.Parameters.Add("@Address2", SqlDbType.VarChar).Value = location.Address2;
                        CMD.Parameters.Add("@City", SqlDbType.VarChar).Value = location.City;
                        CMD.Parameters.Add("@Region", SqlDbType.VarChar).Value = location.RegionName;
                        CMD.Parameters.Add("@Country", SqlDbType.VarChar).Value = location.CountryName;
                        CMD.Parameters.Add("@PostalCode", SqlDbType.VarChar).Value = location.PostalCode;
                        CMD.Parameters.Add("@PreferredLocation", SqlDbType.Bit).Value = location.PreferredLocation;
                        CMD.ExecuteNonQuery();
                    }

                    TRNS.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //TRNS.Rollback();
                return false;
            }
        }

        internal Organization LookupOrganization(int customerID)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {
                    CONN.Open();
                    // Call the view to get a list of organization using a organization ID
                    var CMD = new SqlCommand($"SELECT * FROM v_organization_lookup_id WHERE OrganizationID = {customerID}", CONN);
                    var RDR = CMD.ExecuteReader();
                    var ActiveOrganization = new Organization();
                    while (RDR.Read())
                    {
                        // If an organization is found, fill out the data
                        ActiveOrganization.OrganizationName = RDR["OrganizationName"].ToString();
                        ActiveOrganization.OrgTypeID = (int)RDR["OrganizationTypeID"];
                        ActiveOrganization.OtherOrgType = RDR["OtherOrgType"].ToString();
                        ActiveOrganization.StatusID = (int)RDR["StatusID"];
                    }

                    RDR.Close();
                    return ActiveOrganization;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal Organization LookupOrganizationContact(int customerID, int orgContactID)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {
                    CONN.Open();
                    // Call the stored procedure to find an organization's contact person
                    var CMD = new SqlCommand("spLookupOrganizationContact", CONN);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@OrganizationID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@OrgContactID", SqlDbType.Int).Value = orgContactID;
                    var RDR = CMD.ExecuteReader();
                    var ActiveOrgContact = new Organization();
                    while (RDR.Read())
                    {
                        // If an organization contact is found, fill out the data
                        ActiveOrgContact.OrganizationRoleID = (int)RDR["OrganizationRoleID"];
                        ActiveOrgContact.OtherOrgRole = RDR["OtherOrgRole"].ToString();
                        ActiveOrgContact.PrimaryContact = RDR["PrimaryContact"].ToString();

                        ActiveOrgContact.EmailAddress = RDR["EmailAddress"].ToString();
                        ActiveOrgContact.PhoneNumber = RDR["PhoneNumber"].ToString();
                    }

                    RDR.Close();
                    return ActiveOrgContact;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal List<Location> LookupOrganizationLocation(int customerID, int orgLocationID)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {
                    CONN.Open();
                    // Call the stored procedure to find the organization's locations
                    var CMD = new SqlCommand("spLookupOrganizationLocation", CONN);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = orgLocationID;
                    var RDR = CMD.ExecuteReader();
                    var OrgLocations = new List<Location>();
                    while (RDR.Read())
                    {
                        // For each location found, add it to the list
                        var ActiveLocation = new Location
                        {
                            OrgLocationID = (int)RDR["OrgLocationID"],
                            AddressTypeID = (int)RDR["AddressTypeID"],
                            Address = RDR["Address"].ToString(),
                            Address2 = RDR["Address2"].ToString(),
                            City = RDR["City"].ToString(),
                            RegionName = RDR["Region"].ToString(),
                            CountryName= RDR["Country"].ToString(),
                            PostalCode = RDR["PostalCode"].ToString()
                        };
                        if (!DBNull.Value.Equals(RDR["OrgCustomerID"]))
                            ActiveLocation.OrgCustomerID = (int)RDR["OrgCustomerID"];
                        if (!DBNull.Value.Equals(RDR["PreferredLocation"]))
                            ActiveLocation.PreferredLocation = (bool)RDR["PreferredLocation"];
                        OrgLocations.Add(ActiveLocation);
                    }

                    RDR.Close();
                    return OrgLocations;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal Location LookupOrganizationByLocation(int customerID, int orgLocationID)
        {
            try
            {
                using (var CONN = new SqlConnection(connectionString))
                {
                    CONN.Open();
                    // Call the stored procedure to find the organization's locations
                    var CMD = new SqlCommand("spLookupOrganizationLocation", CONN);
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerID;
                    CMD.Parameters.Add("@OrgLocationID", SqlDbType.Int).Value = orgLocationID;
                    var RDR = CMD.ExecuteReader();
                    var ActiveLocation = new Location();

                    while (RDR.Read())
                    {
                        // For each location found, add it to the list


                        ActiveLocation.OrgLocationID = (int)RDR["OrgLocationID"];
                             ActiveLocation.AddressTypeID = (int)RDR["AddressTypeID"];
                             ActiveLocation.Address = RDR["Address"].ToString();
                            ActiveLocation.Address2 = RDR["Address2"].ToString();
                             ActiveLocation.City = RDR["City"].ToString();
                             ActiveLocation.RegionName= RDR["Region"].ToString();
                            ActiveLocation.CountryName= RDR["Country"].ToString();
                            ActiveLocation.PostalCode = RDR["PostalCode"].ToString();                       
                            ActiveLocation.OrgCustomerID = (int)RDR["OrgCustomerID"];
                            ActiveLocation.PreferredLocation = (bool)RDR["PreferredLocation"];
                    }

                    RDR.Close();
                    return ActiveLocation;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /////////////////////////////////////////////////////////////////
        /// ORGANIZATIONS SEARCH
        /////////////////////////////////////////////////////////////////

        internal List<Organization> GetOrganizations()
        {
            List<Organization> ActiveOrganizations = new List<Organization>();
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getOrganizations = new SqlCommand
            {
                Connection = conn,
                CommandText = "GetOrganizations",
                CommandType = CommandType.StoredProcedure,
                
            };

            SqlDataReader sqlDataReader = getOrganizations.ExecuteReader();
            if(sqlDataReader.Read())
            { 

                while (sqlDataReader.Read())
                {
                    Organization activeOrganization = new Organization();
                    activeOrganization.CustomerID = (int)sqlDataReader["OrganizationID"];
                    activeOrganization.OrgTypeID = (int)sqlDataReader["OrganizationTypeID"];
                    activeOrganization.OrganizationName = Convert.ToString(sqlDataReader["OrganizationName"]);
                    activeOrganization.OtherOrgType = Convert.ToString(sqlDataReader["OtherOrgType"]);
                    ActiveOrganizations.Add(activeOrganization);
                }
            }

            conn.Close();
            return ActiveOrganizations;
        }


        internal int GetOrganizationID(string OrgName)
        {
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getOrganizationid = new SqlCommand
            {
                Connection = conn,
                CommandText = "GetOrganizationID",
                CommandType = CommandType.StoredProcedure

            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "OrganizationName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = OrgName
            };

            getOrganizationid.Parameters.Add(SampleCommandParameter);
            getOrganizationid.ExecuteScalar();
            int organizationid = Convert.ToInt32(getOrganizationid.ExecuteScalar());


            conn.Close();
            return organizationid;

        }



        internal int GetOrganizationLocationID(int OrganizationID)
        {
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getLocationid = new SqlCommand
            {
                Connection = conn,
                CommandText = "GetOrganizationLocationID",
                CommandType = CommandType.StoredProcedure,

            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "OrganizationID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = OrganizationID
            };

            getLocationid.Parameters.Add(SampleCommandParameter);
            getLocationid.ExecuteScalar();
            int locationID = Convert.ToInt32(getLocationid.ExecuteScalar());

            conn.Close();
            return locationID;

        }

        internal List<Customer> LookupOrganizationByValue(string country,string region, string postalCode )
        {
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getOrganization = new SqlCommand
            {
                Connection = conn,
                CommandText = "spLookupOrganizationByValue",
                CommandType = CommandType.StoredProcedure

            };

            SqlParameter SampleCommandParameter;

            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "Country",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = country
            };

            getOrganization.Parameters.Add(SampleCommandParameter);

            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "Region",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = region
            };

            getOrganization.Parameters.Add(SampleCommandParameter);

            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = postalCode
            };

            getOrganization.Parameters.Add(SampleCommandParameter);

            SqlDataReader sqlDataReader = getOrganization.ExecuteReader();

            List<Customer> activeCustomers = new List<Customer>();

            List<Location> OrgLocations = new List<Location>();

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    Customer activeCustomer = new Customer();

                    activeCustomer.CustomerID = (int)sqlDataReader["CustomerID"];
                    activeCustomer.OrganizationName = (string)sqlDataReader["OrganizationName"];
                   
                    //activeCustomer.EmailAddress = (string)sqlDataReader["EmailAddress"];
                    //activeCustomer.OrgLocations = new List<Location>();
                    //Location OrgLocation = new Location();                    
                    //OrgLocation.City = (string)sqlDataReader["City"];
                    //OrgLocation.Region = (string)sqlDataReader["Region"];
                    //OrgLocation.PostalCode = (string)sqlDataReader["PostalCode"];
                    //OrgLocation.Country = (string)sqlDataReader["Country"];
                    //OrgLocations.Add(OrgLocation);
                    //activeCustomer.OrgLocations.Add(OrgLocation);
                    
                    activeCustomers.Add(activeCustomer);
                }
            }
            sqlDataReader.Close();
            conn.Close();
            return activeCustomers;
        }

        public List<OrganizationTypeDetails> GetOrganizationType()
        {
            SqlConnection Connection = Utils.ConnectDB();
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetOrganizationType"
            };

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<OrganizationTypeDetails> SelectedOrganizationTypes = new List<OrganizationTypeDetails>();
            if (SampleDataReader.HasRows)
            {
                while (SampleDataReader.Read())
                {
                    OrganizationTypeDetails SelectedOrganizationType = new OrganizationTypeDetails();

                    SelectedOrganizationType.OrganizationTypeID = (int)SampleDataReader["OrganizationTypeID"];
                    SelectedOrganizationType.OrganizationType = (string)SampleDataReader["OrganizationType"];

                    SelectedOrganizationTypes.Add(SelectedOrganizationType);
                }
            }


            SampleDataReader.Close();
            Connection.Close();

            return SelectedOrganizationTypes;
        }

        public List<OrganizationRoleDetails> GetOrganizationRole()
        {
            SqlConnection Connection = Utils.ConnectDB();
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetOrganizationRole"
            };

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<OrganizationRoleDetails> SelectedOrganizationRoles = new List<OrganizationRoleDetails>();
            if (SampleDataReader.HasRows)
            {
                while (SampleDataReader.Read())
                {
                    OrganizationRoleDetails SelectedOrganizationRole = new OrganizationRoleDetails();

                    SelectedOrganizationRole.OrganizationRoleID = (int)SampleDataReader["OrganizationRoleID"];
                    SelectedOrganizationRole.OrganizationRole = (string)SampleDataReader["OrganizationRole"];

                    SelectedOrganizationRoles.Add(SelectedOrganizationRole);
                }
            }

            SampleDataReader.Close();
            Connection.Close();

            return SelectedOrganizationRoles;
        }

        public List<Location> GetCountries()
        {
            SqlConnection Connection = Utils.ConnectDB();
            Connection.Open();


            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetCountries"
            };


            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<Location> SelectedCountries = new List<Location>();
            if (SampleDataReader.HasRows)
            {
                while (SampleDataReader.Read())
                {
                    Location SelectedCountry = new Location();

                    SelectedCountry.CountryCode = (string)SampleDataReader["CountryCode"];
                    SelectedCountry.CountryName = (string)SampleDataReader["CountryName"];

                    SelectedCountries.Add(SelectedCountry);
                }
            }


            SampleDataReader.Close();
            Connection.Close();

            return SelectedCountries;
        }


        public List<Location> GetRegions()
        {
            SqlConnection Connection = Utils.ConnectDB();
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetRegions"
            };

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<Location> SelectedRegions = new List<Location>();
            if (SampleDataReader.HasRows)
            {
                while (SampleDataReader.Read())
                {
                    Location SelectedRegion = new Location();

                    SelectedRegion.RegionCode = (string)SampleDataReader["RegionCode"];
                    SelectedRegion.RegionName= (string)SampleDataReader["RegionName"];

                    SelectedRegions.Add(SelectedRegion);
                }
            }


            SampleDataReader.Close();
            Connection.Close();

            return SelectedRegions;
        }


        internal int GetOrganizationContactID(int CustomerID)
        {
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getContactid = new SqlCommand
            {
                Connection = conn,
                CommandText = "GetOrganizationContactID",
                CommandType = CommandType.StoredProcedure,

            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "OrganizationID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerID
            };

            getContactid.Parameters.Add(SampleCommandParameter);
            getContactid.ExecuteScalar();
            int OrgContactID = Convert.ToInt32(getContactid.ExecuteScalar());

            conn.Close();
            return OrgContactID;

        }


    }
    
}

#pragma warning restore CS0436 // Type conflicts with imported type