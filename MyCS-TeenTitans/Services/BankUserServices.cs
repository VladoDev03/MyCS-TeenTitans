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

        public BankUserViewDTO MapBankUserViewDTO(BankUser user)
        {
            string accNum = user.AccountNum;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string creditStatus = user.CreditStatus;
            string creditScore = user.CreditScore;

            BankUserViewDTO viewUser = new BankUserViewDTO(
                accNum, firstName, lastName, creditStatus, creditScore);

            return viewUser;
        }

        public BankUserViewDTO ModelToBankUserViewDTO(Model model)
        {
            string accountNumber = model.AccountNum;
            string firstName = model.FirstName;
            string lastName = model.LastName;
            string applicationScore = model.ApplicationScore.ToString();
            string finalDecision = model.FinalDecision;

            BankUserViewDTO userView = new BankUserViewDTO(accountNumber, firstName,
                lastName, finalDecision, applicationScore);

            return userView;
        }

        public void RemoveBankUser(BankUser user)
        {
            context.BankUsers.Remove(user);
            context.SaveChanges();
        }
    }
}
