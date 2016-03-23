using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentRegistration.Model;
using StudentRegistration.Service;

namespace StudentRegistration.WebApp.Controllers
{
  //  [RoutePrefix("api/student")]
    public class StudentController : BaseController
    {
        private StudentService service;

        public StudentController()
        {
            service = new StudentService(Db);
        }

         [HttpPost]
        // [Route("add")]
        [ActionName("add")]
        public IHttpActionResult Add( Student student)
        {
            student.Id = Guid.NewGuid().ToString();
             if (!service.IsCityDuplicate(student.City))
             {
                  string addedId = service.Add(student);
                  return Ok(true);
            }
            else
                return Ok(false);

        }

        [HttpPost]
        //[Route("checkduplicateemail")]
        [ActionName("checkduplicateemail")]
        public IHttpActionResult CheckDuplicateEmail(Student student)
        {
            var isEmailExists = service.IsEmailExists(student.Email);
            if (isEmailExists)
            {
                return Ok(true);
            }
            else
                return Ok(false);
        }
    }
}
