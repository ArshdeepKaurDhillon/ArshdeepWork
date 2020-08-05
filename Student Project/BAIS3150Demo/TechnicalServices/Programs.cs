using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150Demo.Domain;
using System.Data;
using System.Data.SqlClient;

namespace BAIS3150Demo.TechnicalServices
{
    public class Programs
    {
        public bool AddProgram(string ProgramCode, string Description)
        {
            bool Success = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Persist Security Info=false; Integrated Security=true;Database=db1; Server=DESKTOP-3CP1CTN\ArshRavi";
            con.Open();

            SqlCommand com = new SqlCommand
            {
                Connection = con,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddProgram"
            };
            SqlParameter par;
            par = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ProgramCode
            };

            com.Parameters.Add(par);


            par = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = Description
            };

            com.Parameters.Add(par);
            com.ExecuteNonQuery();
            con.Close();
            Success = true;
            return Success;
        }


        public Domain.Program GetProgram(string ProgramCode)
        {
           

            List<Student> EnrolledStudents;
            Students StudentManager = new Students();
            EnrolledStudents = StudentManager.GetStudents(ProgramCode);

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=false; Integrated Security = true; Database = DB1; Server=(localdb)\MSSQLLocalDB";
            Connection.Open();


            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,

                CommandText = "GetProgram"
            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = ProgramCode
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            Domain.Program ActiveProgram = new Domain.Program();
            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();
                ActiveProgram.Description = (string)SampleDataReader["Description"];


            }
            ActiveProgram.EnrolledStudents = EnrolledStudents;

            SampleDataReader.Close();
            Connection.Close();



            return ActiveProgram;
        }


            public List<Student> GetStudents(string programcode)
            {

                List<Student> EnrolledStudents;

                Students StudentManager = new Students();
                EnrolledStudents = StudentManager.GetStudents(programcode);
                return EnrolledStudents;

            }
       
        

    }
}
