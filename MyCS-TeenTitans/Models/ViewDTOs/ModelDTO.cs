using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewDTOs
{
    public class ModelDTO
    {
        public ModelDTO() { }

        public ModelDTO(
               int currentDeliquencyStatus,
               double loanToIncome,
               string occupationCode,
               double bureauScore,
               int timeWithBank)
        {
            CurrentDeliquencyStatus = currentDeliquencyStatus;
            LoanToIncome = loanToIncome;
            OccupationCode = occupationCode;
            BureauScore = bureauScore;
            TimeWithBank = timeWithBank;
        }

        public int CurrentDeliquencyStatus { get; set; }

        public double LoanToIncome { get; set; }

        public string OccupationCode { get; set; }

        public double BureauScore { get; set; }

        public int TimeWithBank { get; set; }
    }
}
