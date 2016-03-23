using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentRegistration.Service;

namespace StudentRegistration.WebApp.Controllers
{
    public class StudentQueryController : BaseController
    {
        private StudentService studentService;
        public StudentQueryController()
        {
             studentService = new StudentService(Db);
        }

        public IHttpActionResult Get()
        {
            var viewModels = studentService.GetAll();
            return Ok(viewModels);
        }
    }
}
