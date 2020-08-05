using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.TechnicalServices
{
    public class PlayerScores
    {
        public bool AddPlayerScore(PlayerScore NewPlayerScore)
        {
            bool Success = false;

            SqlConnection connection1 = new SqlConnection();

            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";

            connection1.Open();

            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "AddPlayerScore";


            SqlParameter SampleCommandParameter1;
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.MemberNumber
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Course",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Course
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Date",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Date
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Rating",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Rating
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Slope",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Slope
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole1",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole1
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole2",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole2
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole3",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole3
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1); 
            
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole4",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole4
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole5",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole5
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
            
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole6",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole6
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
            
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole7",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole7
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole8",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole8
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);


            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole9",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole9
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole10",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole10
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole11",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole11
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
            
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole12",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole12
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole13",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole13
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
           
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole14",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole14

            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);


            SampleCommandParameter1 = new SqlParameter
                {
                    ParameterName = "@Hole15",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = NewPlayerScore.Hole15
                };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
       

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole16",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole16
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);
           
            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole17",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole17
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Hole18",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Hole18
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Score",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.Score
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@HandicapDifferential",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = NewPlayerScore.HandicapDifferential
            };

            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommand1.ExecuteNonQuery();
            Console.WriteLine("Success excellentquery");

            connection1.Close();
            Success = true;
            return Success;
        }

        public double GetHandicapFactor(string MemberNumber)
        {
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = ClubBaistGCMS; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();
            
            double HandicapFactor=1.00;
           
            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetHandicapFactor"
            };
            
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);

            //SqlDataReader SampleDataReader;
            //SampleDataReader = SampleCommand.ExecuteReader();

            HandicapFactor = Convert.ToDouble((double)SampleCommand.ExecuteNonQuery());
            //if (SampleDataReader.HasRows)
            //{
            //    SampleDataReader.Read();

            //    var value = Convert.ToDouble(SampleDataReader["HandicapFacor"]);
            //}

            //SampleDataReader.Close();
           
            Connection.Close();
            return HandicapFactor;
        }
    }
}
