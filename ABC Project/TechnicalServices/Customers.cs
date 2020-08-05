using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Domain;

namespace ABC.TechnicalServices
{
    public class Customers
    {
        public bool AddCustomer(Customer gotCustomer)
        {
            bool Success = false;

            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString =
            @"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
            BAIS3150.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddCustomer"
            };


            SqlParameter AddCommandParameter;


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = gotCustomer.CustomerName
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = gotCustomer.Address
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = gotCustomer.City
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = gotCustomer.Province
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = gotCustomer.PostalCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;
        }

        public Customer GetCustomer(string CustomerName)
        {
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; 
            Database = SALE_DB; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetCustomer"
            };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerName
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            Customer FoundCustomer = new Customer();

            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();

                FoundCustomer.CustomerName = (string)SampleDataReader["CustomerName"];
                FoundCustomer.Address = (string)SampleDataReader["Address"];
                FoundCustomer.City = (string)SampleDataReader["City"];
                FoundCustomer.Province = (string)SampleDataReader["Province"];
                FoundCustomer.PostalCode = (string)SampleDataReader["PostalCode"];

            }


            SampleDataReader.Close();
            Connection.Close();
            return FoundCustomer;
        }


        public bool DeleteCustomer(string CustomerName)
        {
            bool Success = false;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=false;Integrated Security=true;Database=SALE_DB;Server=(localdb)\MSSqlLocalDb";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteCustomer"
            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerName
            };



            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommand.ExecuteNonQuery();

            SampleConnection.Close();
            Success = true;
            return Success;

        }

        public bool UpdateCustomer(Customer modCustomer)
        {
            bool Success = false;

            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString =
            @"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
            BAIS3150.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateCustomer"
            };


            SqlParameter AddCommandParameter;


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modCustomer.CustomerName
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue =modCustomer.Address
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modCustomer.City
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modCustomer.Province
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modCustomer.PostalCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;
        }

    }
}
