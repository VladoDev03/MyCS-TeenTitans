using Data;
using Data.InputModels;
using Data.Models;
using Data.ViewDTOs;
using FileManager;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCS_TeenTitans.Controllers
{
    public class ProcessingController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProcessingController));

        private IBankUserServices userServices;
        private IModelServices modelServices;
        private IFileServices fileServices;
        
        public ProcessingController(IBankUserServices userServices, IModelServices modelServices, IFileServices fileServices)
        {
            this.userServices = userServices;
            this.modelServices = modelServices;
            this.fileServices = fileServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Method for postman
        //To be changed
        //https://localhost:44369/single
        [HttpPost("single")]
        public string SingleCreate([FromBody] ModelInput model)
        {
            string score = modelServices.ProcessData(model).ToString();
            string result = modelServices.MakeDecision(double.Parse(score));

            DecisionViewModel decision = new DecisionViewModel(result, score);

            string resultText = JsonManager.CreateJsonForUserOutput(decision);

            string id = userServices.IdGenerator();

            BankUser bankUser = new BankUser(id, result, score, DateTime.Now);
            userServices.AddBankUser(bankUser);

            _log4net.Info("Executing single check REST API for customer {model.AccountNum} in processing controller");

            return resultText;
        }

        //Method for postman
        //To be changed
        //https://localhost:44369/multy
        [HttpPost("multy")]
        public async Task<string> MultyCreate()
        {
            string path = null;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                path = await reader.ReadToEndAsync();
            }

            _log4net.Info($"Executing multy check REST API for file with path {path} in processing controller");

            return ProcessAllModels(path);
        }

        //Method for UI
        [HttpPost]
        public IActionResult MultyCreateUI(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return RedirectToAction("BatchProcessing", "Home");
            }

            ProcessAllModels(path);
            Console.Beep();
            _log4net.Info($"Executing multy check in UI for file with path {path} in processing controller");
            return RedirectToAction("Index", "Home");
        }

        private string ProcessAllModels(string path)
        {
            List<Model> models = CsvManager.ReadCsv(path);
            List<ModelInput> resultModels = new List<ModelInput>();
            List<BankUser> bankUsersList = new List<BankUser>();

            StringBuilder sb = new StringBuilder();

            foreach (Model model in models)
            {
                ModelInput readyModel = modelServices.ToInputModel(model);

                string score = modelServices.ProcessData(readyModel).ToString();
                string decision = modelServices.MakeDecision(double.Parse(score));
                string id = userServices.IdGenerator();

                resultModels.Add(readyModel);

                BankUser bankUser = new BankUser(id, decision, score, DateTime.Now);
                userServices.AddBankUser(bankUser);
                bankUsersList.Add(bankUser);
            }

            string newPath = CreateNewFile(path, bankUsersList);

            sb.AppendLine($"Directory of processed file:");
            sb.AppendLine(newPath);

            return sb.ToString().Trim();
        }

        private string CreateNewFile(string path, List<BankUser> objects)
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            //String to concat with the name of the input file, in order to make new name for the output file.
            string addString = $"_{day}{month}{year}_{hour}{minute}{second}_result";

            string oldFileName = Path.GetFileNameWithoutExtension(path);

            //string id = userServices.IdGenerator();
            //Data.Models.File file = new Data.Models.File(id, oldFileName, DateTime.Now);

            string newPath = $@"E:\GitRepositories\MyCS-TeenTitans\MyCS-TeenTitans\MyCS-TeenTitans\wwwroot\Files\Output\{oldFileName}{addString}.csv";
            CsvManager.ToCsvFile(objects, newPath);

            return newPath;
        }
    }
}
