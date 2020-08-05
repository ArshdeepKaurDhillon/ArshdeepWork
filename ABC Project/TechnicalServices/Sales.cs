using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Domain;
using static ABC.Domain.Sale;

namespace ABC.TechnicalServices
{
    public class Sales
    {
        public int AddSale(SaleItem ABCSale)
        {

            int SaleNumber;
            SaleNumber = 1;

            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString =
            @"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
            BAIS3150.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddSale"
            };
            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SaleDate",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.SaleDate
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@CustomerName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.CustomerName
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Salesperson",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Salesperson
            };

            AddCommand.Parameters.Add(AddCommandParameter);

          

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Subtotal",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Subtotal
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Gst",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Gst
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@SaleTotal",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.SaleTotal
            };

            AddCommand.Parameters.Add(AddCommandParameter);
            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Time
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommand.ExecuteNonQuery();
            BAIS3150.Close();




               
                BAIS3150.Open();

                SqlCommand SampleCommand = new SqlCommand
                {
                    Connection = BAIS3150,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetSaleNumber"
                };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Time",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Time
                };

                SampleCommand.Parameters.Add(SampleCommandParameter);
              
               ABCSale.SaleNumber= SampleCommand.ExecuteScalar().ToString();

              
               
                                  
               BAIS3150.Close();
        




            //SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString =
            @"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
            BAIS3150.Open();

         
            SqlCommand AddCommand2 = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddSaleItem"
            };
            SqlParameter AddCommandParameter1;

            AddCommandParameter1 = new SqlParameter
            {
                ParameterName = "@SaleNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.SaleNumber
            };

            AddCommand2.Parameters.Add(AddCommandParameter1);

            AddCommandParameter1 = new SqlParameter
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.ItemCode
            };

            AddCommand2.Parameters.Add(AddCommandParameter1);

            AddCommandParameter1 = new SqlParameter
            {
                ParameterName = "@Quantity",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.Quantity
            };

            AddCommand2.Parameters.Add(AddCommandParameter1);

            AddCommandParameter1 = new SqlParameter
            {
                ParameterName = "@ItemTotal",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ABCSale.ItemTotal
            };

            AddCommand2.Parameters.Add(AddCommandParameter1);


            AddCommand2.ExecuteNonQuery();

            BAIS3150.Close();


            //Item ABCItem = new Item();

            //BAIS3150.ConnectionString =
            //@"Persist Security Info = false; Integrated Security = true; Database= SALE_DB; Server=(localdb)\MSSQLLocalDB";
            //BAIS3150.Open();

            //SqlCommand AddCommand2 = new SqlCommand
            //{
            //    Connection = BAIS3150,
            //    CommandType = CommandType.StoredProcedure,
            //    CommandText = "UpdateQuantity"
            //};

            //Item ABCQuan = new Item();

            //AddCommandParameter = new SqlParameter
            //{
            //    ParameterName = "@ItemCode",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    SqlValue = ABCSale.ItemCode
            //};

            //AddCommand2.Parameters.Add(AddCommandParameter);

            //AddCommandParameter = new SqlParameter
            //{
            //    ParameterName = "@Quantity",
            //    SqlDbType = SqlDbType.VarChar,
            //    Direction = ParameterDirection.Input,
            //    SqlValue = ABCItem.Quantity
            //};

            //AddCommand2.Parameters.Add(AddCommandParameter);

            //AddCommand2.ExecuteNonQuery();

            //BAIS3150.Close();


            return SaleNumber;
        }






    }
}
