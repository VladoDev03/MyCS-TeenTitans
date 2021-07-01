using Data;
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
        private IBankUserServices userServices;
        private IModelServices modelServices;
        
        public ProcessingController(IBankUserServices userServices, IModelServices modelServices)
        {
            this.userServices = userServices;
            this.modelServices = modelServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Method for postman
        //To be changed
        //https://localhost:44369/single
        [HttpPost("single")]
        public string SingleCreate([FromBody] Model model)
        {
            string result = JsonManager.CreateJsonForUserOutput(model);

            return result;
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

            return ProcessAllModels(path);
        }

        //Method for UI
        [HttpPost]
        public IActionResult MultyCreateUI(string path)
        {
            string id = userServices.IdGenerator();
            ProcessAllModels(path);
            Console.Beep();
            return RedirectToAction("Index", "Home");
        }

        private string ProcessAllModels(string path)
        {
            List<Model> models = CsvManager.ReadCsv(path);

            StringBuilder sb = new StringBuilder();

            foreach (Model model in models)
            {
                sb.AppendLine(model.ToString());
            }

            string newPath = CreateNewFile(path);
            sb.AppendLine();
            sb.AppendLine($"Directory of processed file:");
            sb.AppendLine(newPath);

            return sb.ToString().Trim();
        }

        private string CreateNewFile(string path)
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            //String to concat with the name of the input file, in order to make new name for the output file.
            string addString = $"_{day}{month}{year}_{hour}{minute}{second}_result";

            string newPath = $@"D:\Yoana\Desktop\MyCS-TeenTitans\MyCS-TeenTitans\MyCS-TeenTitans\wwwroot\Files\Output\FirstModel{addString}.csv";
            System.IO.File.Copy(path, newPath);

            return newPath;
        }
    }
}
