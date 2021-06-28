using Data.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileServices : IFileServices
    {
        private TeenTitansDBContext context;

        public FileServices(TeenTitansDBContext context)
        {
            this.context = context;
        }

        public void AddFile(File file)
        {
            context.Files.Add(file);
            context.SaveChanges();
        }

        public File FindById(string id)
        {
            File file = context.Files.FirstOrDefault(f => f.Id == id);
            return file;
        }

        public File FindByName(string fileName)
        {
            File file = context.Files.FirstOrDefault(f => f.FileName == fileName);
            return file;
        }

        public List<File> GetAllBankFiles()
        {
            List<File> files = context.Files.ToList();
            return files;
        }
    }
}
