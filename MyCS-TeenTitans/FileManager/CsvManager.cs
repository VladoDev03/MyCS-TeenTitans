using CsvHelper;
using Data;
using Data.InputModels;
using Data.Models;
using Data.ViewDTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public static class CsvManager
    {
        public static List<Model> ReadCsv(string path)
        {
            using CsvReader reader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            List<Model> objects = reader.GetRecords<Model>().ToList();

            return objects;
        }

        public static void ToCsvFile(List<BankUser> objects, string path)
        {
            using CsvWriter writer = new CsvWriter(new StreamWriter(path), CultureInfo.InvariantCulture);
            writer.WriteRecords(objects);
        }
    }
}
