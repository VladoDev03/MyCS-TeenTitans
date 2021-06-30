using Data;
using Data.Models;
using Data.ViewDTOs;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BankUserServices : IBankUserServices
    {
        private TeenTitansDBContext context;

        public BankUserServices(TeenTitansDBContext context)
        {
            this.context = context;
        }

        public void AddBankUser(BankUser user)
        {
            context.BankUsers.Add(user);
            context.SaveChanges();
        }

        public void EditBankUser(int id, BankUser newData)
        {
            BankUser user = context.BankUsers
                .FirstOrDefault(u => u.AccountNum == id.ToString());
            user = newData;

            context.SaveChanges();
        }

        public List<BankUser> FindAllWithName(string firstName, string lastName)
        {
            string fullName = $"{firstName} {lastName}".ToLower();

            List<BankUser> bankUsers = context.BankUsers
                .Where(u => $"{u.FirstName.ToLower()} {u.LastName.ToLower()}" == fullName)
                .ToList();

            return bankUsers;
        }

        public BankUser FindByNumber(string number)
        {
            BankUser user = context.BankUsers.FirstOrDefault(bu => bu.AccountNum == number);
            return user;
        }

        public List<BankUser> GetAllBankUsers()
        {
            List<BankUser> users = context.BankUsers.ToList();

            return users;
        }

        public string IdGenerator()
        {
            int length = 11;
            string id = null;

            for (int i = 0; i < length; i++)
            {
                Random random = new Random();
                int part = random.Next(0, 10);
                id += part;
            }

            return id;
        }

        public BankUserViewDTO MapBankUserViewDTO(BankUser user)
        {
            string accNum = user.AccountNum;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string creditStatus = user.CreditStatus;
            string creditScore = user.CreditScore;

            //BankUserViewDTO viewUser = new BankUserViewDTO(
            //    accNum, firstName, lastName, creditStatus, creditScore);

            //return viewUser;

            return new BankUserViewDTO();
        }

        public ModelDTO ModelToBankUserViewDTO(Model model)
        {
            int currentDeliquencyStatus = model.CurrentDeliquencyStatus;
            double loanToIncome = model.LoanToIncome;
            string occupationCode = model.OccupationCode;
            double bureauScore = model.BureauScore;
            int timeWithBank = model.TimeWithBank;

            ModelDTO userView = new ModelDTO(currentDeliquencyStatus, loanToIncome,
                occupationCode, bureauScore, timeWithBank);

            return userView;
        }

        public void RemoveBankUser(BankUser user)
        {
            context.BankUsers.Remove(user);
            context.SaveChanges();
        }
    }
}
