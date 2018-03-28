using MVC_STUDENT_INFO_ANGULARJS.Models;
using MVC_STUDENT_INFO_ANGULARJS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Configuration;

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

        public ActionResult StudentReport()
        {
            string conString = ConfigurationManager.ConnectionStrings["StudentDatabase_ConString"].ToString();
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/CrystalReport"), "CrystalReport_Student.rpt"));
               
                rd.Database.Tables[0].SetDataSource(ds.Tables[0]);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "StudentInformation.pdf");
            }
        }
    }
}
