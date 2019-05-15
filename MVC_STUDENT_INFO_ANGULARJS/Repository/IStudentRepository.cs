using MVC_STUDENT_INFO_ANGULARJS.Models;
using System.Collections.Generic;

namespace MVC_STUDENT_INFO_ANGULARJS.Repository
{
    interface IStudentRepository
    {
        List<Student> SelectAllStudents();       
        void InsertStudent(Student st);
        void UpdateStudent(Student st);
        void DeleteStudent(int id);        
    }
}
