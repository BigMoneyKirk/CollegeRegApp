using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;
using University.Users;

namespace University
{
    public static class Global
    {
        public static int maxStudents = 20;
        public static int maxNumberOfCourses = 15;
        public static int maxNumberOfOneHour = 10;
        public static int maxNumberOfTwoHour = 5;
        public static int numberOf1HourCourses = 0;
        public static int numberOf2HourCourses = 0;

        ///database connection string and different queries (methods)
        public static DataSet GetDisconnectedResult(string connection, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, sqlcon);
                adapter.Fill(ds);
                return ds;
            }
        }

        public static string GetConnectionString()
        {
            return "Data Source=myinstancedemo.chppvnuzl4vk.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RegistrationAppDB;Persist Security Info=True;User ID=stephenkirkland;Password=12345678;Encrypt=False;";
        }

        /// <summary>
        /// the query that inserts a student into the RegistrationAppDB
        /// </summary>
        /// <param name="s">grabs the inserted student's input information</param>
        /// <returns></returns>
        public static string NewStudentQuery(Student s)
        {
            return $"INSERT INTO Student VALUES('{s.Firstname}','{s.Lastname}', '{s.Email}', '{s.Password}', {s.Major}, '{s._status.ToString()}', '{(int)s.IsFulltime}')";
        }

        /// <summary>
        /// push student to the database
        /// </summary>
        public static void NewStudent(Student s)
        {
            GetDisconnectedResult(GetConnectionString(), NewStudentQuery(s));
        }
    }

    public static class Errors
    {
        public static string notEnoughError = "Attempting to add too many students. Not enough space. Cannot add.";
        public static string notCorrectHours = "The class has to be either 1 or 2 credit hours.";
        public static string tooMany1HourCourses = "There can only be at most 10 1-hour courses.";
    }

    /*
     * Understanding partial classes
     
    public partial class Temp
    {
        public void Method111()
        {

        }
    }

    public partial class Temp
    {
        public void Method222()
        {

        }
    }

    public class Temp2
    {
        public void Method111()
        {

        }

        public void Method222()
        {

        }
    }
    */
}
