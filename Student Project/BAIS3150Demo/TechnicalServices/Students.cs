using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BAIS3150Demo.Domain;

namespace BAIS3150Demo.TechnicalServices
{
    public class Students
    {

        public bool AddStudent(Student acceptedStudent, string programCode)
        {
            bool Success = false;

            SqlConnection BAIS3150 = new SqlConnection();
            BAIS3150.ConnectionString = @"Persist Security Info = false; Integrated Security = true; Database= DB1; 
            Server=(localdb)\MSSQLLocalDB";

            BAIS3150.Open();

            SqlCommand AddCommand = new SqlCommand
            {
                Connection = BAIS3150,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };
            SqlParameter AddCommandParameter;

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@StudentId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.StudentId
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.FirstName
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.LastName
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.Email
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);
            AddCommand.ExecuteNonQuery();

            BAIS3150.Close();

            Success = true;

            return Success;
        }




        public Student GetStudent(string StudentID)
        {

            SqlConnection Connection = new SqlConnection();
            Connection.ConnectionString = @"Persist Security Info=False; Integrated Security = True; Database = DB1; Server = (localdb)\MSSQLLocalDB";
            Connection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = Connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent"
            };
            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "StudentId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = StudentID
            };

            SampleCommand.Parameters.Add(SampleCommandParameter);
            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            Student EnrolledStudent = new Student();

            if (SampleDataReader.HasRows)
            {

                SampleDataReader.Read();

                EnrolledStudent.StudentId = (string)SampleDataReader["StudentId"];
                EnrolledStudent.FirstName = (string)SampleDataReader["FirstName"];
                EnrolledStudent.LastName = (string)SampleDataReader["LastName"];
                EnrolledStudent.Email = (string)SampleDataReader["Email"];
            }

            SampleDataReader.Close();
            Connection.Close();
            return EnrolledStudent;

        }

        public bool DeleteStudent(string StudentId)
        {
            bool Success = false;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=false;Integrated Security=true;Database=DB1;Server=(localdb)\MSSqlLocalDb";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStudent"
            };

            SqlParameter SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@StudentId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = StudentId
            };



            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommand.ExecuteNonQuery();

            SampleConnection.Close();
            Success = true;
            return Success;

        }

        public bool UpdateStudent(Student EnrolledStudent)
        {
            bool Success;

            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security InFO=false;Integrated Security=true;Database=DB1;Server=(localdb)\MSSqlLocalDb";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand
            {
                Connection = SampleConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateStudent"
            };
            SqlParameter SampleCommandParameter;
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@StudentId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = EnrolledStudent.StudentId
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = EnrolledStudent.FirstName
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = EnrolledStudent.LastName
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = EnrolledStudent.Email
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommandParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = EnrolledStudent.ProgramCode
            };
            SampleCommand.Parameters.Add(SampleCommandParameter);
            SampleCommand.ExecuteNonQuery();


            SampleConnection.Close();
            Success = true;
            return Success;


        }


        public List<Student> GetStudents(string ProgramCode)
        {
            SqlConnection SampleConnection = new SqlConnection();
            SampleConnection.ConnectionString = @"Persist Security Info=false;Integrated Security=true;Database=DB1;Server=(localdb)\MSSQLLocalDB";
            SampleConnection.Open();

            SqlCommand SampleCommand = new SqlCommand();

            SampleCommand.Connection = SampleConnection;
            SampleCommand.CommandType = CommandType.StoredProcedure;
            SampleCommand.CommandText = "GetStudents";

            SqlParameter SampleParameter = new SqlParameter()
            {
                ParameterName = "@ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = ProgramCode
            };
            SampleCommand.Parameters.Add(SampleParameter);

            SqlDataReader SampleDataReader;
            SampleDataReader = SampleCommand.ExecuteReader();

            List<Student> EnrolledStudents = new List<Student>();

            if (SampleDataReader.HasRows)
            {

                while (SampleDataReader.Read())
                {
                    Student EnrolledStudent = new Student();


                    EnrolledStudent.StudentId = SampleDataReader["StudentId"].ToString();
                    EnrolledStudent.FirstName = SampleDataReader["FirstName"].ToString();
                    EnrolledStudent.LastName = SampleDataReader["LastName"].ToString();
                    EnrolledStudent.Email = SampleDataReader["Email"].ToString();

                    EnrolledStudents.Add(EnrolledStudent);



                }
            }


            SampleDataReader.Close();
            SampleConnection.Close();
            return EnrolledStudents;
        }


       
      

    }
}


