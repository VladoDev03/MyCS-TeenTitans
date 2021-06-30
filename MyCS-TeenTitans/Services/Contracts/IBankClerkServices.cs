using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBankClerkServices
    {
        List<BankClerk> GetAllBankClerks();

        BankClerk FindById(string id);

        void AddBankClerk(BankClerk clerk);

        void EditBankClerk(int id, BankClerk newData);

        void RemoveBankClerk(BankClerk clerk);
    }
}
