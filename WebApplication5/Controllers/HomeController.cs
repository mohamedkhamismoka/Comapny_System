

namespace WebApplication5.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee emp;
        private readonly IDepartment dept;

        public HomeController(ILogger<HomeController> logger, IEmployee emp,IDepartment Dept)
        {
            _logger = logger;
            this.emp = emp;
            dept = Dept;
        }
       //Home page
       //and show count of employees and departments in cards
        public IActionResult Index()
        {

           ViewBag.empCount= emp.getbyfilter().Count();
            ViewBag.deptCount = dept.get().Count(); ;
            return View();
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
