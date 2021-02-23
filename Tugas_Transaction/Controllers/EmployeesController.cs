using API_Tugas_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Tugas_Transaction.Controllers
{
    public class EmployeesController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44352/API/")
        };

        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = null;
            var respondTask = client.GetAsync("Employees"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
            }

            return View(employees);
        }

        public ActionResult Details(int id)
        {
            Employee employees = null;
            var respondTask = client.GetAsync("Employees" + id.ToString()); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();
                employees = readTask.Result;
                Employee emp = employees;

                if (emp == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterViewModel registerVM)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Suppliers", registerVM).Result;

            return RedirectToAction("Index");
        }
    }
}