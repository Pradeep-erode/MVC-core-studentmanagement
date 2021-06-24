using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sample_mvc8.Models;
using Studentmanagement.Core.Mystudent_class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace sample_mvc8.Controllers
{
    public class APIHomeController : Controller
    {
        string apiUrl = ("http://localhost:11973/api/Studendmanagement/Dashboard");
        HttpClient client;
        public APIHomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Mymodelcs student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11973/api/Studendmanagement/Index");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Mymodelcs>(client.BaseAddress, student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View("Index");


            //var counter = interfaca.Check(student);
            //if (counter == 1)
            //{
            //    ViewBag.loginsuccess = 1;
            //    return RedirectToAction("Dashboard");
            //}
            //else
            //{

            //    ViewBag.loginfailed = 2;
            //    return RedirectToAction("Index");
            //}
            
        }
        public ActionResult Create(Mymodelcs student, int id)
        {
            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Mymodelcs student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11973/api/Studendmanagement/Create");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Mymodelcs>(client.BaseAddress, student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View("Dashboard");
        }

            //interfaca.Create(student);
            
        

        public async Task<ActionResult> Dashboard()
        {
            List<Mymodelcs> emp = new List<Mymodelcs>();
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<List<Mymodelcs>>(responseData);
            }
            return View(emp);
        }

        public ActionResult Edit(int studentid)
        {
            
            Mymodelcs student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11973/api/Studendmanagement/");
                
                var responseTask = client.GetAsync("Edit?studentid=" + studentid);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Mymodelcs>();
                    readTask.Wait();

                    student = readTask.Result;
                    return RedirectToAction("Create", student);
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int studentid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11973/api/Studendmanagement/Delete");

                var Deletetask = client.DeleteAsync("?studentid=" + studentid);
                Deletetask.Wait();
                var result = Deletetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }
            return RedirectToAction("Index");

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

