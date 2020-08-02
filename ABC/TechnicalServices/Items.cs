using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Domain;

namespace ABC.TechnicalServices
{
    public class Items
    {
        public bool AddItem(Item acceptedItem)
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
                CommandText = "AddItem"
            };
            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedItem.ItemCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedItem.Description
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedItem.UnitPrice
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Quantity",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedItem.Quantity
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Flag",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedItem.Flag
            };

            AddCommand.Parameters.Add(AddCommandParameter);


            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;


            
        }
        


        public Item GetItem(string ItemCode)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = SALE_DB; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem"
            };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ItemCode
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);
            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            Item GotItem = new Item();

            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();

                GotItem.ItemCode = (string)SampleDataReader["ItemCode"];
                GotItem.Description =(string)SampleDataReader["Description"];
                GotItem.UnitPrice = (string)SampleDataReader["UnitPrice"];
                GotItem.Quantity = (string)SampleDataReader["Quantity"];
                GotItem.Flag = (string)SampleDataReader["Flag"];

            }


            SampleDataReader.Close();
            Connection.Close();
            return GotItem;


        }

        public bool DeleteItem(string ItemCode)
        {
            bool Success = false;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=false;Integrated Security=true;Database=SALE_DB;Server=(localdb)\MSSqlLocalDb";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteItem"
            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue =ItemCode
            };



            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommand.ExecuteNonQuery();

            SampleConnection.Close();
            Success = true;
            return Success;

        }


        public bool UpdateItem(Item modItem)
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
                CommandText = "UpdateItem"
            };
            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modItem.ItemCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modItem.Description
            };

            AddCommand.Parameters.Add(AddCommandParameter);



            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Quantity",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modItem.Quantity
            };

            AddCommand.Parameters.Add(AddCommandParameter);
            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = modItem.UnitPrice
            };

            AddCommand.Parameters.Add(AddCommandParameter);

           

           


            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;
        }


        public bool UpdateFlag(string ItemCode, string Flag)
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
                CommandText = "UpdateFlag"
            };
            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ItemCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Flag",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Flag
            };

            AddCommand.Parameters.Add(AddCommandParameter);



            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;
        }



            public bool UpdateQuantity(Item ABCItem)
            {
                bool Success = false;
                SqlConnection BAIS3150 = new SqlConnection();
                
                //Item ABCItem = new Item();

                BAIS3150.ConnectionString =
                @"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
                BAIS3150.Open();

                SqlCommand AddCommand3 = new SqlCommand
                {
                    Connection = BAIS3150,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "UpdateQuantity"
                };

            //Item ABCQuan = new Item();

            SqlParameter AddCommandParameter3;
                AddCommandParameter3 = new SqlParameter
                {
                    ParameterName = "@ItemCode",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = ABCItem.ItemCode
                };

                AddCommand3.Parameters.Add(AddCommandParameter3);

                AddCommandParameter3 = new SqlParameter
                {
                    ParameterName = "@Quantity",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue =ABCItem.Quantity
                };

                AddCommand3.Parameters.Add(AddCommandParameter3);

                AddCommand3.ExecuteNonQuery();

                BAIS3150.Close();


                Success = true;
            return Success;

            }
        }
}
