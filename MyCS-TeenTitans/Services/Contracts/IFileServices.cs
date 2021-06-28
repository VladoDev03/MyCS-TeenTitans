using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFileServices
    {
        List<File> GetAllBankFiles();

        File FindById(string number);

        File FindByName(string fileName);

        void AddFile(File file);
    }
}
