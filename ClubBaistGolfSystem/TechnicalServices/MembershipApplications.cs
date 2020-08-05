using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBaistGolfSystem.Domain;
using System.Data;
using System.Data.SqlClient;

namespace ClubBaistGolfSystem.TechnicalServices
{
    public class MembershipApplications
    {
        public bool RecordsMembershipApplication(MembershipApplication applicationInformation)
        {

            bool Success = false;

            SqlConnection connection1 = new SqlConnection();

            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";

            connection1.Open();

            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "RecordsMembershipApplication";


            SqlParameter SampleCommandParameter1;

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.FirstName
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.LastName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Address
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.PostalCode
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Phone
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Email
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@DateOfBirth",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.DateOfBirth
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Occupation",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Occupation
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@CompanyName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.CompanyName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@CompanyAddress",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.CompanyAddress
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@CompanyPostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.CompanyPostalCode
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@CompanyPhone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.CompanyPhone
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@ShareholderName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.ShareholderName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Date
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = applicationInformation.Status
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommand1.ExecuteNonQuery();
            Console.WriteLine("Success excellentquery");

            connection1.Close();
            Success = true;
            return Success;
        }



        public List<MembershipApplication> GetMembershipAplications(string Status)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection.Open();



            SqlCommand SampleCommand = new SqlCommand();
            SampleCommand.Connection = connection;
            SampleCommand.CommandType = CommandType.StoredProcedure;
            SampleCommand.CommandText = "GetMembershipApplications";


            SqlParameter SampleCommandParameter;
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = Status
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<MembershipApplication> RequestedApplications = new List<MembershipApplication>();
            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())
                {
                    MembershipApplication OnHoldApplication = new MembershipApplication();
                    OnHoldApplication.MemberApplicationNumber = SampleDataReader["MemberApplicationNumber"].ToString();
                    OnHoldApplication.FirstName = SampleDataReader["FirstName"].ToString();
                    OnHoldApplication.LastName = SampleDataReader["LastName"].ToString();
                    OnHoldApplication.Status = SampleDataReader["Status"].ToString();


                    RequestedApplications.Add(OnHoldApplication);

                }
            }
            SampleDataReader.Close();
            connection.Close();
            return RequestedApplications;


        }


        public bool UpdateMembershipApplication(string MemberApplicationNumber, MembershipApplication newMembershipApplication)
        {

            bool Success;

            SqlConnection connection1 = new SqlConnection();
            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection1.Open();
            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "UpdateMembershipApplication";


            SqlParameter SampleCommandParameter1;

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@MemberApplicationNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = MemberApplicationNumber

            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.FirstName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);



            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.LastName
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.Address
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.PostalCode
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.Phone
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.Email
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newMembershipApplication.Status
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);


            SampleCommand1.ExecuteNonQuery();
            Console.WriteLine("Success excellentquery");

            connection1.Close();
            Success = true;
            return Success;
        }

       

    }

}
