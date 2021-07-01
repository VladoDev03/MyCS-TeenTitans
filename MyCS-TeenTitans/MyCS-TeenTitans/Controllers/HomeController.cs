using Data.InputModels;
using Data.Models;
using Data.ViewDTOs;
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
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HomeController));

        private IBankUserServices userServices;
        private IModelServices modelServices;

        public HomeController(ILogger<HomeController> logger, IBankUserServices userServices, IModelServices modelServices)
        {
            this.userServices = userServices;
            this.modelServices = modelServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _log4net.Info("Logging from index page");

            return View();
        }

        [HttpPost]
        public IActionResult FindClient(string search)
        {
            _log4net.Info("Finding client");

            if (string.IsNullOrEmpty(search))
            {
                return View(nameof(Index));
            }

            BankUser client = userServices.FindByNumber(search);
            return View(nameof(Index), client);
        }

        public IActionResult Privacy()
        {
            _log4net.Info("Logging from privacy page");

            return View();
        }
        
        public IActionResult Login() {
            return View();
        }
        
        public IActionResult SingleProcessing()
        {
            _log4net.Info("Logging from single processing page");

            return View();
        }

        public IActionResult EditClient(string name)
        {
            return View();
        }

        public IActionResult BatchProcessing()
        {
            _log4net.Info("Logging from batch processing page");

            return View();
        }

        public IActionResult DecisionNewClient(string occCode, int currDelStatus, int timeWBank, double bureauScore, string gbFlag, double loanToIncome)
        {
            ModelInput model = new ModelInput();

            model.OccupationCode = occCode;
            model.CurrentDeliquencyStatus = currDelStatus;
            model.TimeWithBank = timeWBank;
            model.BureauScore = bureauScore;
            model.GB_Flag = gbFlag;
            model.LoanToIncome = loanToIncome;

            string score = modelServices.ProcessData(model).ToString();
            string result = Decision(double.Parse(score));

            string id = userServices.IdGenerator();
            BankUser bankUser = new BankUser(id, result, score, DateTime.Now);
            userServices.AddBankUser(bankUser);

            DecisionViewModel decision = new DecisionViewModel(result, score);

            return View(decision);
        }

        [HttpPost]
        public IActionResult DecisionEditClient(string occCode, int currDelStatus, int timeWBank, double bureauScore, string gbFlag, double loanToIncome)
        {
            ModelInput model = new ModelInput();

            model.OccupationCode = occCode;
            model.CurrentDeliquencyStatus = currDelStatus;
            model.TimeWithBank = timeWBank;
            model.BureauScore = bureauScore;
            model.GB_Flag = gbFlag;
            model.LoanToIncome = loanToIncome;

            string score = modelServices.ProcessData(model).ToString();
            string result = Decision(double.Parse(score));

            DecisionViewModel decision = new DecisionViewModel(result, score);

            return View(decision);
        }

        [HttpGet]
        public IActionResult DecisionEditClient(string id)
        {
            BankUser user = userServices.FindByNumber(id);

            return View(user);
        }

        public IActionResult Contacts()
        {
            _log4net.Info("Logging from contacts page");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string Decision(double score)
        {
            if (score <= 292)
            {
                return "Declined";
            }
            else if (score <= 312 && score >= 293)
            {
                return "Refer for further manual assessment";
            }
            else
            {
                return "Accepted";
            }
        }
    }
}
