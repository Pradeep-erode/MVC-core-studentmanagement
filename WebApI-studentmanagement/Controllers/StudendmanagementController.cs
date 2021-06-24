using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Studentmanagement.Core.IService;
using Studentmanagement.Core.Mystudent_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApI_studentmanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudendmanagementController : ControllerBase
    {
        private readonly IServices interfaca;

        public StudendmanagementController(IServices logger)
        {
            interfaca = logger;
        }
        [HttpPost]
        public IActionResult Index(Mymodelcs student)
        {
            var counter = interfaca.Check(student);
            if (counter == 1)
            { 
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public ActionResult Create(Mymodelcs student)
        {
            interfaca.Create(student);
            //var list = interfaca.Dashboard();
            //return RedirectToAction("Dashboard");
            return Ok();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            var list = interfaca.Dashboard();
            return Ok(list);
        }
        [HttpGet]
        public ActionResult Edit(int studentid)
        {
            var student = interfaca.Editing(studentid);
            return Ok(student);
        }
        [HttpDelete]
        public ActionResult Delete(int studentid)
        {
            interfaca.Delete(studentid);
            var list = interfaca.Dashboard();
            return Ok(list);
        }
    }
}
