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
            using (ServiceHost host = new ServiceHost(typeof(EvalService))){
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

