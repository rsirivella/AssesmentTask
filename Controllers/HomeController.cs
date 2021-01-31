using AssesmentTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        LoginRepository lstLogin = new LoginRepository();
        EmployeeData _empData = new EmployeeData();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginData ld)
        {
            bool isLogin = false;
            foreach(var l in lstLogin._loginData)
            {
                if(l.UserName==ld.UserName && l.Password == ld.Password)
                {
                    isLogin = true;
                }
            }
            if (isLogin)
                return Redirect("Employee");
            else
                TempData["msg"] = "Invalid Credentials";

            return View();
        }
        [HttpPost]
        public IActionResult CreateEmp([Bind] Employee emp)
        {
            _empData.CreateEmployee(emp);
            return Redirect("Employee");
            //return View();
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
