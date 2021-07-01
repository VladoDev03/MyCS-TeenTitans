using CsvHelper;
using Data;
using Data.InputModels;
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
        public static List<ModelInput> ReadCsv(string path)
        {
            using CsvReader reader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            List<ModelInput> objects = reader.GetRecords<ModelInput>().ToList();

            return objects;
        }

        public static void ToCsvFile(List<BankUserViewDTO> objects, string path)
        {
            using CsvWriter writer = new CsvWriter(new StreamWriter(path), CultureInfo.InvariantCulture);
            writer.WriteRecords(objects);
        }
    }
}
