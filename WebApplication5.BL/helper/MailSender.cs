using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication5.BL.VM;

namespace WebApplication5.BL.helper
{
    public class MailSender
    {//help sending mails to any comment
        public static void mail(MailVM comm)
        {
            try
            {
               
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("atiffahmykhamis@gmail.com","01065578456M");
                    smtp.Send("atiffahmykhamis@gmail.com", comm.mail, comm.title, comm.body);



              
            }
            catch (Exception e)
            {

            }

        }
    }
    }

