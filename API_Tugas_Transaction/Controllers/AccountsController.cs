using API_Tugas_Transaction.Models;
using API_Tugas_Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_Tugas_Transaction.Controllers
{
    public class AccountsController : ApiController
    {
        readonly AccountRepository accountRepo = new AccountRepository();
        readonly EmployeeRepository employeeRepo = new EmployeeRepository();

        //Update password
        public IHttpActionResult Put(int id, Account account)
        {
            var result = accountRepo.Update(id, account);

            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        //Login
        public IHttpActionResult Post(RegisterViewModel registerVM)
        {
            var email = registerVM.Email;
            var password = registerVM.Password;

            var result = employeeRepo.Get().FirstOrDefault(employee => employee.Email == email && employee.Password == password);

            if(result != null)
            {
                return Ok("Login Succesfully");
            }

            return Ok("Login Failed");
        }
    }
}