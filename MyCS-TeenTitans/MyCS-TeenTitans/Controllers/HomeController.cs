using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCS_TeenTitans.Models;
using Services.Contracts;
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

        private IBankUserServices userServices;

        public HomeController(ILogger<HomeController> logger, IBankUserServices userServices)
        {
            _logger = logger;
            this.userServices = userServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindClient(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View(nameof(Index));
            }

            BankUser client = userServices.FindByNumber(search);
            return View(nameof(Index), client);
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

        public IActionResult BatchProcessing()
        {
            return View();
        }

        public IActionResult DecisionNewClient(string firstName, string lastName)
        {
            //TODO: Add logic to get real decision and score

            string decision = "";
            string score = "";

            if (firstName == "Name")
            {
                decision = "Accepted";
                score = "1000";

            }
            else
            {
                decision = "Rejected";
                score = "500";
            }

            DecisionViewModel model = new DecisionViewModel();
            model.Decision = decision;
            model.Score = score;

            return View(model);
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
