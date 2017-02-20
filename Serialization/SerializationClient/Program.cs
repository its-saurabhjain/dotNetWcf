using SerializationClient.EvalServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EvalServiceClient evalServiceClient = new EvalServiceClient("NetTcpBinding_IEvalService");

            DetailedEval eval;
                
            eval = new DetailedEval();
            eval.From = "SJain";
            eval.Timespent = System.DateTime.Now.ToString();
            eval.What = "1.From Client";
            eval.additional = "1. Additional comments from Client";
            evalServiceClient.SubmitEvals(eval);

            eval = new DetailedEval();
            eval.From = "KJain";
            eval.Timespent = System.DateTime.Now.ToString();
            eval.What = "2. From Client ";
            eval.additional = "2. Additional comments from Client";
            evalServiceClient.SubmitEvals(eval);

            List<Evaluation> evalList= evalServiceClient.GetEvals();

            foreach (var Evaluation in evalList)
            {
                Console.WriteLine($"{Evaluation.What}");
            }
            Console.ReadLine();

        }
    }
}
