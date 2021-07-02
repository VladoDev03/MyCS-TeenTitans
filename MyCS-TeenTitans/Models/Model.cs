using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Model
    {
        public Model() { }

        public Model(
                  //int currentDeliquencyStatus,
                  double loanToIncome,
                  string occupationCode,
                  double bureauScore,
                  int timeWithBank)
        {
            //CurrentDeliquencyStatus = currentDeliquencyStatus;
            loan_to_income = loanToIncome;
            Occupation_Code = occupationCode;
            Bureau_Score = bureauScore;
            Time_with_Bank = timeWithBank;
        }

        //public int CurrentDeliquencyStatus { get; set; }

        //public string GB_Flag { get; set; }

        public string Account_Type { get; set; }

        public string Cheque_Card_Flag { get; set; }

        public string Existing_Customer_Flag { get; set; }

        public int Gross_Annual_Income { get; set; }

        public string Home_Telephone_Number { get; set; }

        public string Insurance_Required { get; set; }

        public int Loan_Amount { get; set; }

        public string Loan_Payment_Frequency { get; set; }

        public string Loan_Payment_Method { get; set; }

        public string Marital_Status { get; set; }

        public int Number_of_Dependants { get; set; }

        public string Occupation_Code { get; set; }

        public string Promotion_Type { get; set; }

        public string Residential_Status { get; set; }

        public int Time_at_Address { get; set; }

        public int Time_in_Employment { get; set; }

        public int Time_with_Bank { get; set; }

        public int Age_of_Applicant { get; set; }

        public double Bureau_Score { get; set; }

        public int SP_ER_Reference { get; set; }

        public int SP_Number_Of_Searches_L6M { get; set; }

        public double loan_to_income { get; set; }

        public override string ToString()
        {
            return $"{loan_to_income} {Occupation_Code} {Bureau_Score} {Time_with_Bank}";
        }
    }
}
