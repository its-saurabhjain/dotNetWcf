using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Base Address for Service
            Uri httpBaseAddress = new Uri(@"http://localhost:4321/chatmgr");
            Uri tcpBaseAddress = new Uri(@"net.Tcp://localhost:4322/serializationDemo");
            using (ServiceHost host = new ServiceHost(
                typeof(ChatManagerService), httpBaseAddress))
            {

                //Add end point
                //host.AddServiceEndpoint(typeof(IChatManager),
                //                                        new WSDualHttpBinding(), "");
                //Add another endpoint
                //host.AddServiceEndpoint(typeof(IChatManager),
                //                                        new NetTcpBinding(), "");
                //Add metadata behavior
                //ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                //serviceBehavior.HttpGetEnabled = true;
                //host.Description.Behaviors.Add(serviceBehavior);

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
