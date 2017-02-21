using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    //[MyErrorHandler]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults =true)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evalList = new List<Eval>();
        public List<Eval> GetEvals()
        {
            //List<Eval> evalList = new List<Eval>();

           return evalList;

        }

        public void SubmitEvals(Eval eval)
        {
            if (eval.Submitter.Equals("throw1"))
                throw new Exception("Something Bad Happened");
            else if (eval.Submitter.Equals("throw2"))
                throw new FaultException("Something Bad Happened",
                                        FaultCode.CreateSenderFaultCode("Bad Submitter Name","http://learningwcf.com/faultexception"));
            else if (eval.Submitter.Equals("throw3"))
                throw new FaultException<BadEvalSubmission>(new BadEvalSubmission());
                evalList.Add(eval);
            Console.WriteLine($" Service received from : {eval.Submitter} at {eval.Timespent}");
        }
    }
}
