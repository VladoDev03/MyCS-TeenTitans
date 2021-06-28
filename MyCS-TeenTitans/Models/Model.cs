using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Model
    {
        public string AccountNum { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ApplicationScore { get; set; }

        public string FinalDecision { get; set; }

        public override string ToString()
        {
            return $"{AccountNum} {FirstName} {LastName} {ApplicationScore} {FinalDecision}";
        }
    }
}
