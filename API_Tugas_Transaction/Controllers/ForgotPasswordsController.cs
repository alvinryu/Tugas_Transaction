using API_Tugas_Transaction.Models;
using API_Tugas_Transaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_Tugas_Transaction.Controllers
{
    public class ForgotPasswordsController : ApiController
    {
        readonly EmployeeRepository employeeRepo = new EmployeeRepository();
        readonly AccountRepository accountRepo = new AccountRepository();

        //Forgot Password
        public IHttpActionResult Post(RegisterViewModel registerVM)
        {
            var checkEmail = employeeRepo.Get().FirstOrDefault(employee => employee.Email == registerVM.Email);

            if(checkEmail != null)
            {
                Guid guid = Guid.NewGuid();
                string newPassword = guid.ToString();

                Account account = new Account();
                account.Id = checkEmail.Id;
                account.Password = newPassword;
                accountRepo.Update(account.Id, account);

                string to = registerVM.Email; //To address    
                string from = "alvinghiffari3@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = "This is your new password <b>" + newPassword + "</b>";
                message.Subject = "Reset Password";
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("alvinghiffari3@gmail.com", "layartancap");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return Ok("Please check your email for your new password");
            }
            else
            {
                return Ok("Email doesn't exist");
            }

        }
    }
}