using System;
using System.Collections.Generic;
using System.Linq;
//Service host
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary;

namespace ServiceHostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Base Address for Service
            Uri httpBaseAddress = new Uri(@"http://localhost:4321/serializationDemo");
            Uri tcpBaseAddress = new Uri(@"net.Tcp://localhost:4322/serializationDemo");
            using (ServiceHost host = new ServiceHost(
                typeof(EvalService), httpBaseAddress, tcpBaseAddress)){
                //Uncomment below code for using FaultException within the ServiceBehavior demo.....
                /*
                ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
                if (sdb == null)
                {
                    sdb = new ServiceDebugBehavior()
                    {
                        HttpHelpPageEnabled = true,
                        IncludeExceptionDetailInFaults = true
                    };
                    host.Description.Behaviors.Add(sdb);
                }
                else
                {
                    sdb.HttpHelpPageEnabled = true;
                    sdb.IncludeExceptionDetailInFaults = true;
                    //sdb.HttpHelpPageUrl = new Uri(serviceAddress +"/help");
                }
                */
                //ServiceEndpoint endpoint = new ServiceEndpoint(contract, new WSHttpBinding, new EndpointAddress(new Uri(serviceAddress)));
                //host.AddServiceEndpoint(endpoint);

                //Add end point
                host.AddServiceEndpoint(typeof(EvalServiceLibrary.IEvalService),
                                                        new BasicHttpBinding(), "");
                //Add another endpoint
                host.AddServiceEndpoint(typeof(EvalServiceLibrary.IEvalService),
                                                        new NetTcpBinding(), "");
                //Add metadata behavior
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(serviceBehavior);

                host.Open();
                PrintServiceDesc(host);
                Console.ReadKey();
            }
       
        }

        private static void PrintServiceDesc(ServiceHost host)
        {
            Console.WriteLine($"{host.Description.ServiceType.Name} is up and Running with the following end points");
            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine($"Address {se.Address.ToString()} {se.Binding.Name}");
            }
        }
    }
}

