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
        List<BankClerk> GetAllBankUsers();

        BankClerk FindById(string id);

        void AddBankUser(BankClerk clerk);
    }
}
