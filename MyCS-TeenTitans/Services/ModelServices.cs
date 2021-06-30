using Data;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ModelServices : IModelServices
    {
        private const double Intercept = 1.41;

        public double ProcessData(Model model)
        {
            double loanToIncomeScore = LoanToIncomeCalculate(model);
            double occupationCodeScore = OccupationCodeCalculate(model);
            double bureauScoreScore = BureauScoreCalculate(model);
            double timeWithBankScore = TimeWithBankCalculate(model);

            double scoreSum = Intercept + loanToIncomeScore + occupationCodeScore + bureauScoreScore + timeWithBankScore;

            return scoreSum;
        }

        public double LoanToIncomeCalculate(Model model)
        {
            double loanToIncomeScore = 0;

            if (model.LoanToIncome < 10)
            {
                loanToIncomeScore = 0.07;
            }
            else if (model.LoanToIncome < 20)
            {
                loanToIncomeScore = -0.63;
            }
            else if (model.LoanToIncome < 30)
            {
                loanToIncomeScore = -0.42;
            }
            else if (model.LoanToIncome < 40)
            {
                loanToIncomeScore = -0.64;
            }
            else if (model.LoanToIncome < 50)
            {
                loanToIncomeScore = -0.50;
            }
            else if (model.LoanToIncome < 60)
            {
                loanToIncomeScore = -0.64;
            }
            else if (model.LoanToIncome < 70)
            {
                loanToIncomeScore = -0.49;
            }
            else if (model.LoanToIncome < 80)
            {
                loanToIncomeScore = -1.08;
            }
            else if (model.LoanToIncome < 90)
            {
                loanToIncomeScore = -0.59;
            }
            else if (model.LoanToIncome < 100)
            {
                loanToIncomeScore = -0.49;
            }
            else
            {
                loanToIncomeScore = -0.80;
            }

            return loanToIncomeScore;
        }

        public double OccupationCodeCalculate(Model model)
        {
            double occupationCodeScore = 0;

            if (model.OccupationCode == "Occupation_Code_B")
            {
                occupationCodeScore = 0.75;
            }
            else if (model.OccupationCode == "Occupation_Code_O|P|M")
            {
                occupationCodeScore = 0.66;
            }

            return occupationCodeScore;
        }

        public double BureauScoreCalculate(Model model)
        {
            double bureauScoreScore = 0;

            if (model.BureauScore < 610)
            {
                bureauScoreScore = 0;
            }
            else if (model.BureauScore < 710)
            {
                bureauScoreScore = -1.51;
            }
            else if (model.BureauScore < 810)
            {
                bureauScoreScore = -0.48;
            }
            else if (model.BureauScore < 910)
            {
                bureauScoreScore = 0.30;
            }
            else if (model.BureauScore < 1010)
            {
                bureauScoreScore = 1.21;
            }
            else
            {
                bureauScoreScore = 1.88;
            }

            return bureauScoreScore;
        }

        public double TimeWithBankCalculate(Model model)
        {
            double timeWithBankScore = 0;

            if (model.TimeWithBank < 500)
            {
                timeWithBankScore = 0.14;
            }
            else if (model.TimeWithBank < 1000)
            {
                timeWithBankScore = 0.22;
            }
            else if (model.TimeWithBank < 1500)
            {
                timeWithBankScore = 0.54;
            }
            else if (model.TimeWithBank < 2000)
            {
                timeWithBankScore = 0.35;
            }
            else
            {
                timeWithBankScore = 0.16;
            }

            return timeWithBankScore;
        }
    }
}
