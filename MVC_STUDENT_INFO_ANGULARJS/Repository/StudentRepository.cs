using MVC_STUDENT_INFO_ANGULARJS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MVC_STUDENT_INFO_ANGULARJS.Repository
{
    public class StudentRepository : IStudentRepository
    {
        string conString = ConfigurationManager.ConnectionStrings["StudentDatabase_ConString"].ToString();
        List<Student> studentList = new List<Student>();
        public List<Models.Student> SelectAllStudents()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    studentList.Add(
                        new Student
                        {
                            StudentID = Convert.ToInt32(dr["StudentID"]),
                            Name = dr["Name"].ToString(),
                            Class = dr["Class"].ToString(),
                            Age = Convert.ToInt32(dr["Age"]),
                            PresentAddress = dr["PresentAddress"].ToString(),
                            PermanentAddress = dr["PermanentAddress"].ToString(),
                            Attendance = Convert.ToInt32(dr["Attendance"])
                        }
                        );
                };
            }
            return studentList;
        }

        public void InsertStudent(Models.Student st)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", st.Name);
                cmd.Parameters.AddWithValue("@Class", st.Class);
                cmd.Parameters.AddWithValue("@Age", st.Age);
                cmd.Parameters.AddWithValue("@PresentAddress", st.PresentAddress);
                cmd.Parameters.AddWithValue("@PermanentAddress", st.PermanentAddress);
                cmd.Parameters.AddWithValue("@Attendance", st.Attendance);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Models.Student st)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", st.StudentID);
                cmd.Parameters.AddWithValue("@Name", st.Name);
                cmd.Parameters.AddWithValue("@Class", st.Class);
                cmd.Parameters.AddWithValue("@Age", st.Age);
                cmd.Parameters.AddWithValue("@PresentAddress", st.PresentAddress);
                cmd.Parameters.AddWithValue("@PermanentAddress", st.PermanentAddress);
                cmd.Parameters.AddWithValue("@Attendance", st.Attendance);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.ExecuteNonQuery();
            }
        }        
    }
}