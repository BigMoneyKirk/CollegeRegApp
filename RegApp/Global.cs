using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;

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
