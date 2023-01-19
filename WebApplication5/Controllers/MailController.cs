using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication5.BL.helper;
using WebApplication5.BL.VM;

namespace WebApplication5.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
       public IActionResult Index()
        {
           return View();
             
        }
        [HttpPost]
        //recireve mailV object to send this data to reciever
        public async Task<IActionResult> send(MailVM comm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailSender.mail(comm);
                 
                    return RedirectToAction("Index", "Home");
                }
               
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["x"] = e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
