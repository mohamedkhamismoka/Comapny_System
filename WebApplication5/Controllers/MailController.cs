

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
