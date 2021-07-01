using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewDTOs
{
    public class DecisionViewModel
    {
        public DecisionViewModel(string decision, string score)
        {
            Decision = decision;
            Score = score;
        }

        public string Decision { get; set; }
        public string Score { get; set; }
    }
}
