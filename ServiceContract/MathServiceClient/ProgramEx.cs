using MathServiceClient.MathServiceExReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceClient
{
    class ProgramEx
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

            SimpleMathExClient mathClient = new SimpleMathExClient("BasicHttpBinding_SimpleMathEx");
            MathInputs inputs = new MathInputs();
            inputs.x = x;
            inputs.y = y;
            string userid = "saurabh";

            Console.WriteLine($"Add: {mathClient.add(userid, inputs)}");
            Console.WriteLine($"Add: {mathClient.sub(userid, inputs)}");



            Console.ReadLine();
        }
    }
}
