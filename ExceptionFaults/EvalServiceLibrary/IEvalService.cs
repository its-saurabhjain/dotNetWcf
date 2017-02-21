using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Contains Service Contract
using System.ServiceModel;

namespace EvalServiceLibrary
{
    [ServiceContract]
    public interface IEvalService
    {
        [FaultContract(typeof(BadEvalSubmission))]
        [OperationContract]
        void SubmitEvals(Eval eval);
        [OperationContract]
        List<Eval> GetEvals();
    }
}
