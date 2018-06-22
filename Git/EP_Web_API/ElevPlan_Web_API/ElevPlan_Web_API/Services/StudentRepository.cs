using ElevPlan_Web_API.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ElevPlan_Web_API.Services
{
    public class StudentRepository
    {
        public StudentRepository()
        {
        }
        private static StudentRepository instance;

        public static StudentRepository Instance
        {
            get
            {
                if (instance == null)
                { instance = new StudentRepository(); }
                return instance;
            }
        }

        private string sqlConn;
        private MySqlConnection MysqlConnection = null;

        private void ConnectMySql()
        {

            sqlConn = @"server=10.108.48.19; Database=EP_Web_API; User Id=EPAdmin; Password=K4ff3; integrated security=false; SslMode=none;";

            if (MysqlConnection == null)
            {
                MysqlConnection = new MySqlConnection(sqlConn);
            }

            try
            {
                MysqlConnection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("####################Failed to connect to sql server: " + ex);
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                ConnectMySql();
                MySqlCommand cmd = new MySqlCommand("SELECT Student.name, Line.lineName, Education.name, EducationSpecialization.name, Period.activity, Firm.name, Period.startDate, Period.endDate, Internship.startDate, Internship.endDate FROM Student " +
                                                        "JOIN EducationSpecialization ON Student.studentType = EducationSpecialization.id " +
                                                        "JOIN Education ON EducationSpecialization.educationId = Education.id JOIN Period ON Period.studentId = Student.id " +
                                                        "JOIN Line ON Period.lineId = Line.lineId " +
                                                        "JOIN Internship ON Student.id = Internship.studentId " +
                                                        "JOIN Firm ON Internship.firmId = Firm.firmId", MysqlConnection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    students.Add(new Student(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetDateTime(6), rdr.GetDateTime(7), rdr.GetDateTime(8), rdr.GetDateTime(9)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("############################FAILED: " + ex);
            }
            finally
            {
                MysqlConnection.Close();
            }

            //students.Add(

            //    new Student
            //    {
            //        Name = "Henrik",
            //        Occupation = "Praktik",
            //        Activity = "Hovedforløb",
            //        Education = "Data/It",
            //        Specialization = "IT Supporter",
            //        Firm = "Synergi",
            //        PeriodStartDate = DateTime.Now,
            //        PeriodEndDate = DateTime.Now.AddDays(100),
            //        InternshipStartDate = DateTime.Now,
            //        InternshipEndDate = DateTime.Now.AddDays(95)

            //    }
            //    );
            //students.Add(

            //    new Student
            //    {
            //        Name = "Ole",
            //        Occupation = "Praktik",
            //        Activity = "VirksomhedsPraktik",
            //        Education = "Data/It",
            //        Specialization = "Programmør",
            //        Firm = "Atea",
            //        PeriodStartDate = DateTime.Now,
            //        PeriodEndDate = DateTime.Now.AddDays(100),
            //        InternshipStartDate = DateTime.Now,
            //        InternshipEndDate = DateTime.Now.AddDays(95)
            //    }
            //);

            return students;
        }
    }
}