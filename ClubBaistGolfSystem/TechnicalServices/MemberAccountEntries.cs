using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.TechnicalServices
{
    public class MemberAccountEntries
    {
        public List<MemberAccountEntry> GetAccountEntry(string MemberAccountNumber)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=false; Integrated Security = true; Database = ClubBaistGCMS; Server=(localdb)\MSSQLLocalDB";
            Connection.Open();


            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,

                CommandText = "GetMemberAccountEntry"
            };

            SqlParameter SampleCommandParameter;

            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@MemberAccountNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = MemberAccountNumber
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);


            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<MemberAccountEntry> newMemberAccountEntries = new List<MemberAccountEntry>();

            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())
                 
                {
                    MemberAccountEntry newMemberAccountEntry = new MemberAccountEntry();
                    newMemberAccountEntry.Amount = Convert.ToDouble(SampleDataReader["Amount"]);
                    newMemberAccountEntry.ActivityDate = Convert.ToString(SampleDataReader["ActivityDate"]);
                    newMemberAccountEntry.PostedDate = Convert.ToString(SampleDataReader["PostedDate"]);
                    //newMemberAccountEntry.Description = (string)SampleDataReader["Description"];

                    newMemberAccountEntries.Add(newMemberAccountEntry);
                }

               

            }

            SampleDataReader.Close();
            Connection.Close();
            return newMemberAccountEntries;
        }
    }

}
