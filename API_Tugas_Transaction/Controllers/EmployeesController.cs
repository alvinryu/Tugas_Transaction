using API_Tugas_Transaction.Models;
using API_Tugas_Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_Tugas_Transaction.Controllers
{
    public class EmployeesController : ApiController
    {
        readonly EmployeeRepository employeeRepo = new EmployeeRepository();

        //Create or Register Employee
        public IHttpActionResult Post(RegisterViewModel registerViewModel)
        {
            var result = employeeRepo.Create(registerViewModel);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult Get()
        {
            var result = employeeRepo.Get();

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await employeeRepo.Get(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Data Not Found");
        }
    }
}