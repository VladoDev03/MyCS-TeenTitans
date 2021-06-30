using Data.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BankClerkServices : IBankClerkServices
    {
        private TeenTitansDBContext context;

        public BankClerkServices(TeenTitansDBContext context)
        {
            this.context = context;
        }

        public void AddBankClerk(BankClerk clerk)
        {
            context.Add(clerk);
            context.SaveChanges();
        }

        public void EditBankClerk(int id, BankClerk newData)
        {
            BankClerk clerk = context.BankClerks
                .FirstOrDefault(c => c.Id == id.ToString());
            clerk = newData;

            context.SaveChanges();
        }

        public BankClerk FindById(string id)
        {
            BankClerk clerk = context.BankClerks.FirstOrDefault(c => c.Id == id);
            return clerk;
        }

        public List<BankClerk> GetAllBankClerks()
        {
            List<BankClerk> clerks = context.BankClerks.ToList();
            return clerks;
        }

        public void RemoveBankClerk(BankClerk clerk)
        {
            context.Remove(clerk);
            context.SaveChanges();
        }
    }
}
