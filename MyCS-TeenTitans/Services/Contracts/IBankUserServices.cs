using Data.Models;
using Data.ViewDTOs;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBankUserServices
    {
        List<BankUser> GetAllBankUsers();

        BankUser FindByNumber(string number);

        List<BankUser> FindAllWithName(string firstName, string lastName);

        void AddBankUser(BankUser user);

        BankUserViewDTO ModelToBankUserViewDTO(Model model);

        void EditBankUser(int id, BankUser newData);
    }
}
