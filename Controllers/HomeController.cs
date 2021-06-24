using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sample_mvc8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Studentmanagement.Core;
using Studentmanagement.Core.IService;
using Studentmanagement.Core.Mystudent_class;
using System.Net.Http;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;

namespace sample_mvc8.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices interfaca;

        public HomeController(IServices logger)
        {
            interfaca = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Mymodelcs student)
        {
            var counter=interfaca.Check(student);
            if (counter == 1)
            {
                ViewBag.loginsuccess = 1;
                return RedirectToAction("Dashboard");
            }
            else
            {
               
                ViewBag.loginfailed = 2;
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Create(Mymodelcs student,int id)
        {
            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Mymodelcs student)
        {  
           interfaca.Create(student);
           return RedirectToAction("Dashboard", student);
        }
       
        public ActionResult Dashboard()
        {
            var list = interfaca.Dashboard();
            return View(list);
        }

        public ActionResult Edit(int studentid)
        {
            var student = interfaca.Editing(studentid);
            return RedirectToAction("Create", student);
        }
        public ActionResult Delete(int studentid)
        {
            interfaca.Delete(studentid);
            return RedirectToAction("Dashboard");
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
