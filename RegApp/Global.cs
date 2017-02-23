using System;
using System.Data;
using System.Data.SqlClient;
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
        public static int majorCount = 0;
        private static bool studentReadClosed = false;
        private static bool majorReadClosed = false;
        private static bool courseReadClosed = false;
        public static int grabThatCourseID;

        #region DATABASE
        /*
         *------------------------------------------DATABASE CONNECTIONS----------------------------------------------------- 
        */
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

        #region ReadResults
        /// <summary>
        /// I want to read the information from my database and present it to my view.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        public static void ShowReadResultForMajors(string connection, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand(query, sqlcon);
                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // the rest was set up; this is what we want.

                    while (reader.Read() && !majorReadClosed)
                    {
                        Major m = new Major((int)reader[0], reader[1].ToString());
                        University2.AddMajor(m);
                        majorCount++;
                    }
                    majorReadClosed = true;
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void WriteStudentsToUniversity(string connection, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand(query, sqlcon);
                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && !studentReadClosed)
                    {
                        int a = (int)reader[0];
                        string b = reader[1].ToString();
                        string c = reader[2].ToString();
                        string d = reader[3].ToString();
                        string e = reader[4].ToString();
                        int f = (int)reader[5];
                        Status g = (Status)reader[6];
                        bool h = (bool)reader[7];
                        Student s = new Student(a, b, c, d, e, f, g, h);
                        University2.AddStudent(s);
                    }
                    studentReadClosed = true;
                    reader.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /*
         *-------------------------------------------COURSE STUFF--------------------------------------------------------
        */

        /// <summary>
        /// Want to display the names of the course and their availablity. May incorporate them as a sorted table by time.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="query"></param>
        public static void ShowReadResultForCourses(string connection, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand(query, sqlcon);
                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && !courseReadClosed)
                    {
                        int a = (int)reader[0];
                        string b = reader[1].ToString();
                        int d = (int)reader[2];
                        string e = reader[3].ToString();
                        bool f = (bool)reader[4];
                        Course c = new Course(a, b, d, e, f);
                        University2.AddCourse(c);
                    }
                    courseReadClosed = true;
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static string PullCourseByIDQuery(int id)
        {
            return $"SELECT * FROM Course where CourseID = {id}";
        }
        #endregion ReadResults

        /// <summary>
        /// String that declares the connection to my database (RegistrationAppDB)
        /// </summary>
        /// <returns>a connection string</returns>
        public static string GetConnectionString()
        {
            return "Data Source=myinstancedemo.chppvnuzl4vk.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RegistrationAppDB;Persist Security Info=True;User ID=stephenkirkland;Password=12345678;Encrypt=False;";
        }
        #endregion DATABASE


        /*
         *---------------------------------STUDENT STUFF---------------------------------------------- 
        */

        /// <summary>
        /// the query that inserts a student into the RegistrationAppDB
        /// </summary>
        /// <param name="s">grabs the inserted student's input information</param>
        /// <returns></returns>
        public static string NewStudentQuery(Student s)
        {
            return $"INSERT INTO Student VALUES('{s.Firstname}','{s.Lastname}', '{s.Email}', '{s.Password}', {s.MajorID}, {(int)s.Grade}, '{s.IsFulltime}', {s.studentCreditHours})";
        }

        /// <summary>
        /// push student to the database
        /// </summary>
        public static void NewStudent(Student s)
        {
            GetDisconnectedResult(GetConnectionString(), NewStudentQuery(s));
        }

        /// <summary>
        /// I want to grab the students for the RegistrationAppDB in order to allow them to register to a course, etc.
        /// </summary>
        public static string GrabStudentsfromDBQuery()
        {
            return "SELECT FirstName, LastName FROM Student";
        }
         
        /*
         *-----------------------------------------MAJOR STUFF---------------------------------------------------------- 
        */

        public static string GetMajorsFromDBQuery()
        {
            return "SELECT * FROM Major";
        }

        /*
         *----------------------------------------SELECT LIST---------------------------------------------------------- 
        */
        

    } // GLOBAL CLASS

    public static class Errors
    {
        public static string notEnoughError = "Attempting to add too many students. Not enough space. Cannot add.";
        public static string notCorrectHours = "The class has to be either 1 or 2 credit hours.";
        public static string tooMany1HourCourses = "There can only be at most 10 1-hour courses.";
    }
}
