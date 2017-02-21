using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Users;

namespace University.Courses
{
    public interface ICourse
    {
        // methods
        bool AddStudent(Student student);
        bool AddStudents(List<Student> roster);
        void RemoveStudent(int id);
        bool RemoveStudent(Student student);
        bool RemoveStudent(string firstname, string lastname);
        Student GetStudentByID(int id);
        List<Student> GetStudentByFirstName(string firstname);
        Task<List<Student>> GetStudentRoster();

        // properties
        string CourseName { get; set; }
        int CreditHours { get; set; }
        string CourseTime { get; set; }
        bool isFull { get; }
        int RosterCount { get; }
    }
}
