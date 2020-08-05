using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.TechnicalServices
{
    public class Members
    {
        public bool AddMember(Member memberDetails)
        {

            bool Success = false;

            SqlConnection connection1 = new SqlConnection();

            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";

            connection1.Open();

            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "AddMember";


            SqlParameter SampleCommandParameter1;
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.MemberNumber
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.FirstName
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.LastName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Address",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.Address
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.PostalCode
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.Phone
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.Email
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
           
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@MemberType",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = memberDetails.MemberType
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
