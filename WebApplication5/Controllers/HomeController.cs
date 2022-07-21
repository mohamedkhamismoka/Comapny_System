using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.BL.interfaces;
using WebApplication5.DAL.Database;
using WebApplication5.Models;

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

            int [] arra = { emp.getbyfilter().Count(),dept.get().Count() };
            return View(arra);
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
