using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;


namespace ClubBaistGolfSystem.TechnicalServices
{ 
    class TeeSheet
    {

        public List<TeeTime> GetTeeSheet(DateTime Date)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection.Open();



            SqlCommand SampleCommand = new SqlCommand();
            SampleCommand.Connection = connection;
            SampleCommand.CommandType = CommandType.StoredProcedure;
            SampleCommand.CommandText = "GetTeeSheet";


            SqlParameter SampleCommandParameter;
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = Date
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<TeeTime> RequestedTeeSheet = new List<TeeTime>();
            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())
                {
                    TeeTime RequestedTeeTime = new TeeTime();
                    RequestedTeeTime.Date = Convert.ToDateTime(SampleDataReader["Date"].ToString()).ToShortDateString();
                    RequestedTeeTime.Time = SampleDataReader["Time"].ToString();
                    RequestedTeeTime.NumberOfCarts = SampleDataReader["NumberOfCarts"].ToString();
                    RequestedTeeTime.NumberOfPlayers = SampleDataReader["NumberOfPlayers"].ToString();
                    RequestedTeeTime.PlayerFirstName = SampleDataReader["PlayerFirstName"].ToString();
                    RequestedTeeTime.PlayerLastName = SampleDataReader["PlayerLastName"].ToString();
                    RequestedTeeTime.Phone= SampleDataReader["Phone"].ToString();
                    RequestedTeeSheet.Add(RequestedTeeTime);

                }
            }
            SampleDataReader.Close();
            connection.Close();
            return RequestedTeeSheet;
            
            
        }

             public bool AddTeeTime(TeeTime selectedTeeTime)
             {

                bool Success = false;

                SqlConnection connection1 = new SqlConnection();
                connection1.ConnectionString =
                @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
                connection1.Open();
                SqlCommand SampleCommand1 = new SqlCommand();
                SampleCommand1.Connection = connection1;
                SampleCommand1.CommandType = CommandType.StoredProcedure;
                SampleCommand1.CommandText = "AddTeeTime";


                SqlParameter SampleCommandParameter1;

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@Date",
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.Date


                };
                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@Time",
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.Time
                };

                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@NumberOfCarts",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.NumberOfCarts
                };
                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@NumberOfPlayers",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.NumberOfPlayers
                };
                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@PlayerFirstName",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.PlayerFirstName
                };
                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@PlayerLastName",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue =  selectedTeeTime.PlayerLastName
                };

                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@Phone",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = selectedTeeTime.Phone
                };

                SampleCommand1.Parameters.Add(SampleCommandParameter1);

                SampleCommand1.ExecuteNonQuery();
                Console.WriteLine("Success excellentquery");

                connection1.Close();
                Success = true;
                return Success;
             }

        public TeeTime GetTeeTime(DateTime Date, DateTime Time)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=false; Integrated Security = true; Database = ClubBaistGCMS; Server=(localdb)\MSSQLLocalDB";
            Connection.Open();


            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,

                CommandText = "GetTeeTime"
            };

            SqlParameter SampleCommandParameter;

            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Date
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);


            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Time
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);


            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();
            TeeTime SelectedTime = new TeeTime();
            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();
                SelectedTime.PlayerFirstName = (string)SampleDataReader["PlayerFirstName"];
                SelectedTime.PlayerLastName = (string)SampleDataReader["PlayerLastName"];
                SelectedTime.Phone = (string)SampleDataReader["Phone"];

              
            }

            SampleDataReader.Close();
            Connection.Close();



            return SelectedTime;
        }

        public bool UpdateTeeTime(DateTime Date,DateTime Time, TeeTime selectedTime)
        {

            bool Success;

            SqlConnection connection1 = new SqlConnection();
            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";
            connection1.Open();
            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "UpdateTeeTime";


            SqlParameter SampleCommandParameter1;

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Date


            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                SqlValue = Time
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

                    

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@PlayerFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = selectedTime.PlayerFirstName
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@PlayerLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = selectedTime.PlayerLastName
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Phone",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = selectedTime.Phone
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

