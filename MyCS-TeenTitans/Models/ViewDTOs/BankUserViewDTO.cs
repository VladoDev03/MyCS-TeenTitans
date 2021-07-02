using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewDTOs
{
    public class BankUserViewDTO
    {
        public BankUserViewDTO() {  }

        public BankUserViewDTO(
               string accountNum,
               int currentDeliquencyStatus,
               double loanToIncome,
               string occupationCode,
               double bureauScore,
               int timeWithBank,
               string decision,
               string score,
               string error = null)
        {
            AccountNum = accountNum;
            CurrentDeliquencyStatus = currentDeliquencyStatus;
            LoanToIncome = loanToIncome;
            OccupationCode = occupationCode;
            BureauScore = bureauScore;
            TimeWithBank = timeWithBank;
            Decision = decision;
            Score = score;
            Error = error;
        }

        public string AccountNum { get; set; }

        public int CurrentDeliquencyStatus { get; set; }

        public double LoanToIncome { get; set; }

        public string OccupationCode { get; set; }

        public double BureauScore { get; set; }

        public int TimeWithBank { get; set; }

        public string GB_Flag { get; set; }

        public string Decision { get; set; }

        public string Score { get; set; }

        public string Error { get; set; }

        public override string ToString()
        {
            return $"{CurrentDeliquencyStatus} {LoanToIncome} {OccupationCode} {BureauScore} {TimeWithBank} {GB_Flag} {Decision} {Score}";
        }
    }
}
