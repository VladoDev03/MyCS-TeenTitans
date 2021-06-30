using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCS_TeenTitans.Models;
using Services;
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
        public IBankUserServices BankUserService { get; set; }
        public HomeController(IBankUserServices bankUserService, ILogger<HomeController> logger)
        {
            this.BankUserService = bankUserService;
            _logger = logger;

        }

        public IActionResult Index(string accountNumber)
        {
            // TODO: Setup database 
            // TOOD: Populate records in the database 
            // TODO: Call service to find user by account number
            if (String.IsNullOrWhiteSpace(accountNumber))
            {
                return View();
            } else
            {
                //BankUser user = this.BankUserService.FindByNumber(accountNumber);
                BankUser user = new BankUser("1", "Test", "Testov", "Ok", "250", new DateTime(2021, 12, 31));

                return View(user);
            }
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

        public IActionResult EditClient(string accountNumber)
        {
            // TODO: Call service to get data and popualte the model(Model for the form that has all the input fields)
            EditClientViewModel user = new EditClientViewModel();
            //EditClientViewModel user = this.BankUserService.FindByNumber(accountNumber);

            return View(user);
        }

        public IActionResult BachProcessing()
        {
            return View();
        }

        public IActionResult DecisionNewClient(string firstName, string lastName)
        {
            //TODO: Add logic to get real decision and score
            var decision = "";
            var score = "";
            if(firstName == "Simona")
            {
                decision = "Accepted";
                score = "1000";
                
            } else
            {
                decision = "Rejected";
                score = "500";
            }

            DecisionViewModel model = new Data.Models.DecisionViewModel();
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
