using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.TechnicalServices
{
    class StandingTeeTimeRequests
    {
        public List<StandingTeeTime> GetStandingTeeTime(DateTime RequestedStartDate)
        {
            SqlConnection connection2 = new SqlConnection();
            connection2.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection2.Open();



            SqlCommand SampleCommand2 = new SqlCommand();
            SampleCommand2.Connection = connection2;
            SampleCommand2.CommandType = CommandType.StoredProcedure;
            SampleCommand2.CommandText = "GetStandingTeeTime";


            SqlParameter SampleCommandParameter2;
            SampleCommandParameter2 = new SqlParameter
            {
                ParameterName = "@RequestedStartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = RequestedStartDate
            };
            SampleCommand2.Parameters.Add(SampleCommandParameter2);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand2.ExecuteReader();

            List<StandingTeeTime> StandingTeeTimes = new List<StandingTeeTime>();

            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())
                {

                    StandingTeeTime RequestedStandingTeeTime = new StandingTeeTime();
                    RequestedStandingTeeTime.RequestedStartDate = Convert.ToDateTime(SampleDataReader["RequestedStartDate"].ToString()).ToShortDateString();
                    RequestedStandingTeeTime.MemberNumber = SampleDataReader["MemberNumber"].ToString();
                    RequestedStandingTeeTime.MemberFirstName = SampleDataReader["MemberFirstName"].ToString();
                    RequestedStandingTeeTime.MemberLastName = SampleDataReader["MemberLastName"].ToString();
                    RequestedStandingTeeTime.DayOfWeek = SampleDataReader["DayOfWeek"].ToString();
                    RequestedStandingTeeTime.RequestedTeeTime = SampleDataReader["RequestedTeeTime"].ToString();
                    RequestedStandingTeeTime.RequestedStartDate = SampleDataReader["RequestedStartDate"].ToString();
                    RequestedStandingTeeTime.RequestedEndDate = SampleDataReader["RequestedEndDate"].ToString();
                    StandingTeeTimes.Add(RequestedStandingTeeTime);

                }
            }

            SampleDataReader.Close();
            connection2.Close();
            return StandingTeeTimes;
        }



        public bool AddStandingTeeTime(StandingTeeTime RequestedStandingTeeTime)
        {

            bool Success = false;
            SqlConnection connection3 = new SqlConnection();
            connection3.ConnectionString =
            @"Persist Security Info = false; Integrated Security = true; Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection3.Open();

            SqlCommand SampleCommand3 = new SqlCommand();
            SampleCommand3.Connection = connection3;
            SampleCommand3.CommandType = CommandType.StoredProcedure;
            SampleCommand3.CommandText = "AddStandingTeeTime";

            SqlParameter SampleCommandParameter3;
            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.MemberNumber
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@MemberFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.MemberFirstName
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@MemberLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.MemberLastName
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@DayOfWeek",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.DayOfWeek
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@RequestedTeeTime",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.RequestedTeeTime
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);


            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@RequestedStartDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.RequestedStartDate
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommandParameter3 = new SqlParameter()
            {
                ParameterName = "@RequestedEndDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = RequestedStandingTeeTime.RequestedEndDate
            };

            SampleCommand3.Parameters.Add(SampleCommandParameter3);

            SampleCommand3.ExecuteNonQuery();
            Console.WriteLine("Excellent Non Query");
            connection3.Close();
            Success = true;
            return Success;
        }

          public StandingTeeTime SearchStandingTeeTime(string MemberNumber)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = ClubBaistGCMS; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "SearchStandingTeeTime"
            };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);
            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            StandingTeeTime SearchedStandingTeeTime= new StandingTeeTime();

            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();

                SearchedStandingTeeTime.MemberFirstName =(string)SampleDataReader["MemberFirstName"];
                SearchedStandingTeeTime.MemberLastName = (string)SampleDataReader["MemberLastName"];
               

            }


            SampleDataReader.Close();
            Connection.Close();
            return SearchedStandingTeeTime;


        }

        public bool DeleteStandingTeeTimeRequest(string MemberNumber)
        {
            bool Success = false;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=false;Integrated Security=true;Database=ClubBaistGCMS;Server=(localdb)\MSSqlLocalDb";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStandingTeeTimeRequest"
            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };



            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommand.ExecuteNonQuery();

            SampleConnection.Close();
            Success = true;
            return Success;

        }
    }
}