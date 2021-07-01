using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InputModels
{
    public class ModelInput
    {
        public int CurrentDeliquencyStatus { get; set; }

        public double LoanToIncome { get; set; }

        public string OccupationCode { get; set; }

        public double BureauScore { get; set; }

        public int TimeWithBank { get; set; }

        public string GB_Flag { get; set; }
    }
}
