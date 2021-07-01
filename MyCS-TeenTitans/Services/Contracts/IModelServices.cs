using Data;
using Data.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IModelServices
    {
        double ProcessData(ModelInput model);

        string MakeDecision(double score);
    }
}
