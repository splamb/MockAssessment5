using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockAssessment5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Calculator()
        {
            return View();
        }

        public IActionResult Result([Bind("num1", "num2", "operation")] Calculator newCalc)
        {

                if (newCalc.operation == "Plus")
                {
                    ViewBag.Result = (newCalc.num1 + newCalc.num2).ToString();
                    ViewBag.Operation = "Plus";
                }
                else if (newCalc.operation == "Minus")
                {
                    ViewBag.Result = (newCalc.num1 - newCalc.num2).ToString();
                    ViewBag.Operation = "Minus";
                }
                else if (newCalc.operation == "Multiply")
                {
                    ViewBag.Result = (newCalc.num1 * newCalc.num2).ToString();
                    ViewBag.Operation = "Multiply";
                }
                else
                {
                    ViewBag.Result = (newCalc.num1 / newCalc.num2).ToString();
                    ViewBag.Operation = "Divide";
                }
            
            return View("Result");
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
