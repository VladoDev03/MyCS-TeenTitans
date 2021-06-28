using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewDTOs
{
    public class BankUserViewDTO
    {
        public BankUserViewDTO(
               string accountNum, string firstName,
               string lastName, string creditStatus,
               string creditScore)
        {
            AccountNum = accountNum;
            FirstName = firstName;
            LastName = lastName;
            CreditStatus = creditStatus;
            CreditScore = creditScore;
        }

        public string AccountNum { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CreditStatus { get; set; }

        public string CreditScore { get; set; }
    }
}
