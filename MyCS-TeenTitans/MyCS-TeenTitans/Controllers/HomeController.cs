using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCS_TeenTitans.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCS_TeenTitans.Controllers
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
        
        public IActionResult Login() {
            return View();
        }
        
        public IActionResult SingleProcessing()
        {
            return View();
        }

        public IActionResult EditClient(string name)
        {
            return View();
        }

        public IActionResult BachProcessing()
        {
            return View();
        }

        public IActionResult DecisionNewClient()
        {
            return View();
        }

        public IActionResult DecisionEditClient()
        {
            return View();
        }

        public IActionResult Contacts()
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
