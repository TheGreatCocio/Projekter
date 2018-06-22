using ElevPlan_Web_API.Models;
using ElevPlan_Web_API.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ElevPlan_Web_API.Controllers
{
    public class StudentController : ApiController
    {
        // GET: Student        

        public IHttpActionResult Get()
        {
            List<Student> students = new List<Student>();
            try
            {
                students = StudentRepository.Instance.GetAllStudents();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            return Ok(students);
        }
    }
}