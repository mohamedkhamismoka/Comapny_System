

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
        public async Task<IActionResult> Index(MailVM comm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var x=MailSender.mail(comm);
                    if (x)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                       TempData["message"] = "there is Error try again please";
                        return View();
                    }
                 
                 
                }
               
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["message"] = "there is Error try again please";
                return View();
            }

        }
    }
}
