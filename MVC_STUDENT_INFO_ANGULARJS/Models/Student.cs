using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_STUDENT_INFO_ANGULARJS.Models
{
    public class Student
    {
        [Display(Name="Student ID")]
        public int StudentID { get; set; }
        [Required(ErrorMessage="Name field is mandatory")]
        public string Name { get; set; }
        public string Class { get; set; }
        public Nullable<int> Age { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int Attendance { get; set; }
    }
}