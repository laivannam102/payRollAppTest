using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rollAppTest1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using rollAppTest1.Models;

namespace rollAppTest1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Customer(string userName)
        {
            EmployeeDb empDB = new EmployeeDb();
            var Emp = userName != null ? empDB.userDetail(userName) : null;
            ViewBag.Message = "hao nam dt";

            return View(Emp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
