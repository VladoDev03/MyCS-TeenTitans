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

        public static string CreateJsonForUserOutput(DecisionViewModel decision)
        {
            string text = JsonSerializer.Serialize(decision, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return text;
        }
    }
}
