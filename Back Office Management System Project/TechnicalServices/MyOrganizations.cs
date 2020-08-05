using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOM.Domain;
using System.Data;
using System.Data.SqlClient;


namespace BOM.TechnicalServices
{
    public class MyOrganizations
    {
        //public bool AddOrganization(Organization NewCustomer)
        //{
        //    bool Success = false;

        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @"Persist Security Info=false; Integrated Security=true;Database=ICCP_BOM; Server=(localdb)\MSSQLLocalDB";
        //    con.Open();

        //    ////////////////////////////////////////////////////////////////
        //    /// CREATE ORGANIZATION
        //    ////////////////////////////////////////////////////////////////

        //    SqlCommand createOrganization = new SqlCommand
        //    {
        //        Connection = con,
        //        CommandType = CommandType.StoredProcedure,
        //        CommandText = "spCreateOrganization"
        //    };
        //    SqlParameter par;
        //    par = new SqlParameter
        //    {
        //        ParameterName = "@OrganizationName",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.OrgName
        //    };

        //    createOrganization.Parameters.Add(par);

        //    par = new SqlParameter
        //    {
        //        ParameterName = "@OrganizationTypeID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.OrgTypeID
        //    };
        //    createOrganization.Parameters.Add(par);


        //    par = new SqlParameter
        //    {
        //        ParameterName = "@CustomerID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Output

        //    };

        //    createOrganization.Parameters.Add(par);

        //    var CustomerID = createOrganization.ExecuteNonQuery();

        //    con.Close();

        //    con.Open();

        //    SqlCommand addOrganizationLocation = new SqlCommand
        //    {
        //        Connection = con,
        //        CommandType = CommandType.StoredProcedure,
        //        CommandText = "spAddOrganizationLocationNew"
        //    };

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@CustomerID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = CustomerID
        //    });



        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Address",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Address
        //    });

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Country",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Country
        //    });

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Region",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Region
        //    });

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@City",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.City
        //    });

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@PreferredLocation",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.PreferredLocation
        //    });

        //    //addOrganizationLocation.Parameters.Add(new SqlParameter
        //    //{
        //    //    ParameterName = "@OrgLocationName",
        //    //    SqlDbType = SqlDbType.VarChar,
        //    //    Direction = ParameterDirection.Input,
        //    //    SqlValue = "Edmonton"
        //    //}); 

        //    addOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@OrgLocationID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Output,

        //    });


        //    var LocationID = addOrganizationLocation.ExecuteNonQuery();
        //    con.Close();

        //    con.Open();

        //    SqlCommand updateOrganizationLocation = new SqlCommand()
        //    {
        //        Connection = con,
        //        CommandType = CommandType.StoredProcedure,
        //        CommandText = "spUpdateOrganizationLocation"
        //    };

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@CustomerID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = CustomerID
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@OrgLocationID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = LocationID
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@AddressTypeID",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.AddressTypeID
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Address",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Address
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Address2",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Address2
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@City",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.City
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Region",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Region
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@Country",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.Country
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@PostalCode",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.PostalCode
        //    });

        //    updateOrganizationLocation.Parameters.Add(new SqlParameter
        //    {
        //        ParameterName = "@PreferredLocation",
        //        SqlDbType = SqlDbType.Int,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = NewCustomer.PreferredLocation
        //    });

        //    updateOrganizationLocation.ExecuteNonQuery();


        //    con.Close();
        //    Success = true;
        //    return Success;
        //}

        public int GetOrganizationID(string OrganizationName)
        {
            SqlConnection conn = Utils.ConnectDB();
            conn.Open();

            SqlCommand getOrganizationid = new SqlCommand
            {
                Connection = conn,
                CommandText = "GetOrganizationID",
                CommandType = CommandType.StoredProcedure,

            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "OrganizationName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = OrganizationName
            };

            getOrganizationid.Parameters.Add(SampleCommandParameter);

            getOrganizationid.ExecuteScalar();
            int organizationID = Convert.ToInt32(getOrganizationid.Parameters["OrganizationName"].Value);


            conn.Close();
            return organizationID;

        }

        public Organization LookUpOrganization(int CustomerID)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = ICCP_BOM; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.TableDirect,
                CommandText = "SELECT * FROM v_organization_lookup_id WHERE OrganizationID = {customerID}"
            };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "OrganizationID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerID
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);
            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            Organization ActiveOrganization = new Organization();

            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())

                ActiveOrganization.OrganizationName = (string)SampleDataReader["OrganizationName"];
                ActiveOrganization.OrgTypeID = (int)SampleDataReader["OrganizationTypeID"];
                ActiveOrganization.StatusID = (int)SampleDataReader["StatusID"];
            }

            SampleDataReader.Close();
            Connection.Close();
            return ActiveOrganization;
        }

        //public List<Location> LookUpOrganizationLocation(int CustomerID, int OrgLocationID)
        //{

        //    SqlConnection Connection = new SqlConnection();
        //    Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = ICCP_BOM; Server = (localdb)\MSSQLLocalDB";
        //    Connection.Open();

        //    SqlCommand SampleCommand = new SqlCommand
        //    {
        //        Connection = Connection,
        //        CommandType = CommandType.StoredProcedure,
        //        CommandText = "spLookupOrganizationLocation"
        //    };

        //    SqlParameter SampleCommandParameter = new SqlParameter();
        //    SampleCommandParameter = new SqlParameter
        //    {
        //        ParameterName = "CustomerID",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = CustomerID
        //    };

        //    SampleCommand.Parameters.Add(SampleCommandParameter);

        //    SampleCommandParameter = new SqlParameter
        //    {
        //        ParameterName = "OrgLocationID",
        //        SqlDbType = SqlDbType.VarChar,
        //        Direction = ParameterDirection.Input,
        //        SqlValue = OrgLocationID
        //    };

        //    SampleCommand.Parameters.Add(SampleCommandParameter);

        //    SqlDataReader SampleDataReader;
        //    SampleDataReader = SampleCommand.ExecuteReader();


        //    List<Location> OrgLocations = new List<Location>();
        //    if (SampleDataReader.HasRows)
        //    {

        //        while (SampleDataReader.Read())
        //        {
        //            Location ActiveLocation = new Location();
        //            ActiveLocation.OrgLocationID = (int)SampleDataReader["OrgLocationID"];
        //            ActiveLocation.AddressTypeID = (int)SampleDataReader["AddressTypeID"];
        //            ActiveLocation.Address = (string)SampleDataReader["Address"];
        //            ActiveLocation.Address2 = (string)SampleDataReader["Address2"];
        //            ActiveLocation.City = (string)SampleDataReader["City"];
        //            ActiveLocation.Region = (string)SampleDataReader["Region"];
        //            ActiveLocation.Country = (string)SampleDataReader["Country"];
        //            ActiveLocation.PostalCode = (string)SampleDataReader["PostalCode"];

        //            OrgLocations.Add(ActiveLocation);
        //        }
        //    }

        //    SampleDataReader.Close();
        //    Connection.Close();
        //    return OrgLocations;
        //}



        public bool UpdateOrg(Organization  ActiveOrganization)
        {
            bool Success;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = ICCP; Server = (localdb)\MSSQLLocalDB";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateOrg"
            };
            SqlParameter SampleCommandParameter;
           
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@OrganizationID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ActiveOrganization.CustomerID
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
           
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@OrganizationName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ActiveOrganization.OrganizationName
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
           
            
           
            SampleCommand.ExecuteNonQuery();


            SampleConnection.Close();
            Success = true;
            return Success;


        }
























    }
}
