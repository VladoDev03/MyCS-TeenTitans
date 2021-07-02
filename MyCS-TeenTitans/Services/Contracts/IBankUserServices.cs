using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ViewDTOs;

namespace Services.Contracts
{
    public interface IBankUserServices
    {
        List<BankUser> GetAllBankUsers();

        BankUser FindByNumber(string number);

        List<BankUser> FindAllWithName(string firstName, string lastName);

        void AddBankUser(BankUser user);

        void EditBankUser(int id, BankUser newData);

        void RemoveBankUser(BankUser user);

        string IdGenerator();
    }
}
