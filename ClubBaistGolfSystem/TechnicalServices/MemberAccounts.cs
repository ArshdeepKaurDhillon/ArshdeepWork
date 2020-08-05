using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClubBaistGolfSystem.Domain;

namespace ClubBaistGolfSystem.TechnicalServices
{
    public class MemberAccounts
    {
        public bool AddMemberAccount(MemberAccount accountDetails)
        {
            List<MemberAccountEntry> memberAccountEntries = new List<MemberAccountEntry>();
            MemberAccountEntry memberAccountEntry = new MemberAccountEntry();
            bool Success = false;

            SqlConnection connection1 = new SqlConnection();
            connection1.ConnectionString =
            @"Persist Security Info=False;Integrated Security=True;Database=ClubBaistGCMS;server=(localdb)\MSSQLLocalDB";

            connection1.Open();

            SqlCommand SampleCommand1 = new SqlCommand();
            SampleCommand1.Connection = connection1;
            SampleCommand1.CommandType = CommandType.StoredProcedure;
            SampleCommand1.CommandText = "AddMemberAccount";


            SqlParameter SampleCommandParameter1;         

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@MemberAccountNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.MemberNumber
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.Balance
            };
            SampleCommand1.Parameters.Add(SampleCommandParameter1);

            SampleCommand1.ExecuteNonQuery();
            var MemberNumber = Convert.ToInt32(SampleCommand1.Parameters["@MemberAccountNumber"].Value);
            connection1.Close();

            connection1.Open();
            
            SqlCommand SampleCommand2 = new SqlCommand();
            SampleCommand2.Connection = connection1;
            SampleCommand2.CommandType = CommandType.StoredProcedure;
            SampleCommand2.CommandText = "AddMemberAccountEntry";

            SqlParameter SampleParameter2;

            SampleParameter2 = new SqlParameter
            {
                ParameterName = "@MemberAccountNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = MemberNumber
            };
            SampleCommand2.Parameters.Add(SampleParameter2);

            SampleParameter2 = new SqlParameter
            {
                ParameterName = "@Amount",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.Entries[0].Amount
            };
            SampleCommand2.Parameters.Add(SampleParameter2);
            
            SampleParameter2 = new SqlParameter
            {
                ParameterName = "@ActivityDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.Entries[0].ActivityDate
            };
            SampleCommand2.Parameters.Add(SampleParameter2);

            SampleParameter2 = new SqlParameter
            {
                ParameterName = "@PostedDate",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.Entries[0].PostedDate
            };
            SampleCommand2.Parameters.Add(SampleParameter2);

            SampleParameter2 = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = accountDetails.Entries[0].Description
            };
            SampleCommand2.Parameters.Add(SampleParameter2);

            SampleCommand2.ExecuteNonQuery();


            //foreach(var Entry in accountDetails.Entries)
            //{

            //    SqlCommand SampleCommand3 = new SqlCommand();
            //    SampleCommand3.Connection = connection1;
            //    SampleCommand3.CommandType = CommandType.StoredProcedure;
            //    SampleCommand3.CommandText = "AddMemberAccountEntry";

            //    SqlParameter SampleParameter3;

            //    SampleParameter3 = new SqlParameter
            //    {
            //        ParameterName = "@MemberAccountNumber",
            //        SqlDbType = SqlDbType.Int,
            //        Direction = ParameterDirection.Input,
            //        SqlValue = MemberNumber
            //    };
            //    SampleCommand3.Parameters.Add(SampleParameter3);

            //    SampleParameter3 = new SqlParameter
            //    {
            //        ParameterName = "@Amount",
            //        SqlDbType = SqlDbType.Int,
            //        Direction = ParameterDirection.Input,
            //        SqlValue = Entry.Amount
            //    };
            //    SampleCommand3.Parameters.Add(SampleParameter3);

            //    SampleParameter3 = new SqlParameter
            //    {
            //        ParameterName = "@ActivityDate",
            //        SqlDbType = SqlDbType.Date,
            //        Direction = ParameterDirection.Input,
            //        SqlValue = Entry.ActivityDate
            //    };
            //    SampleCommand3.Parameters.Add(SampleParameter3);

            //    SampleParameter3 = new SqlParameter
            //    {
            //        ParameterName = "@PostedDate",
            //        SqlDbType = SqlDbType.Date,
            //        Direction = ParameterDirection.Input,
            //        SqlValue = Entry.PostedDate
            //    };
            //    SampleCommand3.Parameters.Add(SampleParameter3);

            //    SampleParameter3 = new SqlParameter
            //    {
            //        ParameterName = "@Description",
            //        SqlDbType = SqlDbType.VarChar,
            //        Direction = ParameterDirection.Input,
            //        SqlValue = Entry.Description
            //    };
            //    SampleCommand3.Parameters.Add(SampleParameter3);

            //    SampleCommand3.ExecuteNonQuery();
            //}

            connection1.Close();
            Success = true;
            return Success;

        }
        public MemberAccount GetMemberAccount(string MemberAccountNumber)
        {
            List<MemberAccountEntry> newMemberAccountEntries;
            MemberAccountEntries MemberAccountEntryManager = new MemberAccountEntries();
            newMemberAccountEntries = MemberAccountEntryManager.GetAccountEntry(MemberAccountNumber);
            
            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=false; Integrated Security = true; Database = ClubBaistGCMS; Server=(localdb)\MSSQLLocalDB";
            Connection.Open();


            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,

                CommandText = "GetMemberAccount"
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

            MemberAccount SelectedAccount = new MemberAccount();


            if (SampleDataReader.HasRows)
            {
                SampleDataReader.Read();

                SelectedAccount.Balance = Convert.ToDouble(SampleDataReader["Balance"]);

            }

            SelectedAccount.Entries = newMemberAccountEntries;

            SampleDataReader.Close();
            Connection.Close();
            return SelectedAccount;
        }


        public List<MemberAccountEntry> GetAccountEntry(string MemberAccountNumber)
        {

            List<MemberAccountEntry> newMemberAccountEntries;

            MemberAccountEntries MemberAccountEntryManager = new MemberAccountEntries();
            newMemberAccountEntries = MemberAccountEntryManager.GetAccountEntry(MemberAccountNumber);
            return newMemberAccountEntries;

        }
    }
}
