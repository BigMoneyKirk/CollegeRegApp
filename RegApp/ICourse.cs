using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Users;

namespace University.Courses
{
    interface ICourse
    {
        // methods
        bool AddStudent(Student student);
        bool AddStudents(List<Student> roster);
        bool RemoveStudent(int id);
        bool RemoveStudent(Student student);
        bool RemoveStudent(string firstname, string lastname);
        Student GetStudentByID(int id);
        List<Student> GetStudentByFirstName(string firstname);
        Task<List<Student>> GetStudentRoster();

        // properties
        string Title { get; }
        TimeSpan CreditHours { get; }
        bool isFull { get; }
        int RosterCount { get; }
    }
}
