using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication5.BL.VM;

namespace WebApplication5.Controllers
{
    public class MailController : Controller
    {
       public IActionResult Index()
        {
            var data = new MailVM
            {
                mail = "",
                body = "",
                password = "",

            };
           
            return View(data);
        }
        [HttpPost]
        //recireve mailV object to send this data to reciever
        public IActionResult send(MailVM comm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(comm.mail, comm.password);
                    smtp.Send(comm.mail, "atiffahmykhamis@gmail.com", comm.title, comm.body);
                    TempData["x"]="Email Sent successfully";
                    return RedirectToAction("Index");
                }
                TempData["x"] = "Email  Not Sent ";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["x"] = "Email  Not Sent ";
                return RedirectToAction("Index");
            }

        }
    }
}
