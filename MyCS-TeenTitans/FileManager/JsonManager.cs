using Data;
using Data.ViewDTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileManager
{
    public static class JsonManager
    {
        public static Model ReadJson(string path)
        {
            Model model = JsonSerializer.Deserialize<Model>(path);

            return model;
        }

        public static void CreateJsonFromModel(Model model, string path)
        {
            string text = JsonSerializer.Serialize(model, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, text);
        }

        public static string CreateJsonFromModel(Model model)
        {
            string text = JsonSerializer.Serialize(model, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return text;
        }

        public static string CreateJsonForUserOutput(Model model)
        {
            string accountNumber = model.AccountNum;
            string firstName = model.FirstName;
            string lastName = model.LastName;
            string applicationScore = model.ApplicationScore.ToString();
            string finalDecision = model.FinalDecision;

            BankUserViewDTO userView = new BankUserViewDTO(accountNumber, firstName,
                lastName, finalDecision, applicationScore);

            string text = JsonSerializer.Serialize(userView, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return text;
        }
    }
}
