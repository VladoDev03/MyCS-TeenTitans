using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class BankUser
    {
        public BankUser(
            string accountNum, string firstName,
            string lastName, string creditStatus,
            string creditScore, DateTime dateOfLastScore)
        {
            AccountNum = accountNum;
            FirstName = firstName;
            LastName = lastName;
            CreditStatus = creditStatus;
            CreditScore = creditScore;
            DateOfLastScore = dateOfLastScore;
        }

        public string AccountNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditStatus { get; set; }
        public string CreditScore { get; set; }
        public DateTime DateOfLastScore { get; set; }
    }
}
