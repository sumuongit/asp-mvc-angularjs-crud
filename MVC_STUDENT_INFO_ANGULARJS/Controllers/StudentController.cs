using MVC_STUDENT_INFO_ANGULARJS.Models;
using MVC_STUDENT_INFO_ANGULARJS.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_STUDENT_INFO_ANGULARJS.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository rep = new StudentRepository();
       
        public ActionResult Index()
        {  
            return View();
        }

        [HttpGet]
        public JsonResult GetAllStudents()
        {
            List<Student> obj = rep.SelectAllStudents();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStudentById(int id)
        {
            Student obj = rep.SelectAllStudents().Find(x=>x.StudentID.Equals(id));
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void InsertStudent(Student st)
        {            
            rep.InsertStudent(st);           
        }

        [HttpPost]
        public void UpdateStudent(Student st)
        {
            rep.UpdateStudent(st);
        }

        [HttpPost]
        public void DeleteStudent(int id)
        {
            rep.DeleteStudent(id);            
        }       
    }
}
