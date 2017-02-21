using MathServiceClient.MathServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*MathClient mathClient = new MathClient("BasicHttpBinding_IMath");
            Console.WriteLine($"Add: {mathClient.Add(3.5, 4.5)}");
            Console.WriteLine($"Subtract: {mathClient.Add(4.5, 3.5)}");
            Console.WriteLine($"Multiply: {mathClient.Add(3.5, 4.5)}");
            Console.WriteLine($"Division: {mathClient.Add(3.5, 4.5)}");*/

            Console.WriteLine("Press Enter to run the client.........");
            Console.ReadLine();

            Console.WriteLine("Enter X:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y:");
            double y = double.Parse(Console.ReadLine());

            SimpleMathClient mathClient = new SimpleMathClient("BasicHttpBinding_SimpleMath");
            try
            {
                Console.WriteLine($"Add: {mathClient.add(x, y)}");
                Console.WriteLine($"Subtract: {mathClient.sub(x, y)}");
                //Console.WriteLine($"Multiply: {mathClient.mul(x, y)}");
                //Console.WriteLine($"Division: {mathClient.div(x, y)}");
                List<double> numbers = new List<double>();
                numbers.Add(3.5);
                numbers.Add(3.5);
                numbers.Add(3.5);
                //mathClient.addList(numbers);
                Console.WriteLine("Call is Completed.......");

                //mathClient.addList(numbers);
                Console.WriteLine("Call is Completed.......");

                //mathClient.addList(numbers);
                Console.WriteLine("Call is Completed.......");
            }
            catch (FaultException fe)
            {
                Console.WriteLine(fe.Reason);
            }
            Console.ReadLine();
        }
    }
}
