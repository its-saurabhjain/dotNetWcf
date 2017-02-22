using SecurityClient.EvalLibServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SerializationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Command to Execute Submit/Get, <Exit> to exit");
            string command = Console.ReadLine();
            if (command.Equals("Exit")) goto close;
            //EvalServiceClient evalServiceClient = new EvalServiceClient("BasicHttpBinding_IEvalService");
            //Basic client credential type with Transport mode
     
            EvalServiceClient evalServiceClient = new EvalServiceClient("WSHttpBinding_IEvalService");
            evalServiceClient.ClientCredentials.UserName.UserName = "saurabh";
            evalServiceClient.ClientCredentials.UserName.Password = "sj@01012017";

            //EvalServiceClient evalServiceClient = new EvalServiceClient("NetTcpBinding_IEvalService");
            while (!command.Equals("Exit"))
            {
                try
                {
                    switch (command.ToLower())
                    {
                        case "submit":
                            Console.WriteLine("Enter Submitter");
                            string submitter = Console.ReadLine();
                            Console.WriteLine("Enter Comments");
                            string comments = Console.ReadLine();
                            Submit(evalServiceClient, submitter, comments);
                            break;

                        case "get":
                            GetAll(evalServiceClient);
                            break;
                        default:
                            Console.WriteLine("Incorrect input Enter Submit/Get");
                            break;
                    }
                }
              catch (FaultException e)
                {
                    Console.WriteLine("FaultException handler is called");
                    Console.WriteLine(e.Message);
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("CommunicationException handler is called");
                    Console.WriteLine(ce.Message);
                }
                catch (TimeoutException te)
                {
                    Console.WriteLine("Timeout handler is called");
                    Console.WriteLine(te.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine("General Exception is called");
                    Console.WriteLine(e.Message);
                }
                finally {

                    if (evalServiceClient.State == CommunicationState.Faulted)
                        Console.WriteLine("Clinet Channel has faulted...Creating new channel");
                    evalServiceClient.Abort();
                    evalServiceClient = new EvalServiceClient("NetTcpBinding_IEvalService");
                }
                Console.WriteLine("\n Enter Command to Execute Submit/Get, <Exit> to exit");
                if (command.Equals("Exit")) goto close;
                command = Console.ReadLine();
            }
            Console.ReadLine();
        close: Console.WriteLine(".........");
        }
        private static void Submit(EvalServiceClient evalServiceClient, string submitter, string comment)
        {
            Evaluation eval;
            eval = new Evaluation();
            eval.From = submitter;
            eval.Timespent = System.DateTime.Now.ToString();
            eval.What = comment;
            evalServiceClient.SubmitEvals(eval);

        }
        private static void GetAll(EvalServiceClient evalServiceClient)
        {
            List<Evaluation> evalList = evalServiceClient.GetEvals();

            foreach (var Evaluation in evalList)
            {
                Console.WriteLine($"{Evaluation.What}");
            }

        }
    }
}
