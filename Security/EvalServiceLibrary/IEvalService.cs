using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Contains Service Contract
using System.ServiceModel;
using System.Net.Security;

namespace EvalServiceLibrary
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IEvalService
    {
        [OperationContract]
        void SubmitEvals(Eval eval);
        [OperationContract]
        List<Eval> GetEvals();
    }
}
