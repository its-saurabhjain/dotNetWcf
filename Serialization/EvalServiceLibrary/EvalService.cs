using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
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
            evalList.Add(eval);
            Console.WriteLine($" Service received from : {eval.Submitter} at {eval.Timespent}");
        }
    }
}
