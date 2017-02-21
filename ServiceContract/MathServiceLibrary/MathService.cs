using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace MathServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Name ="SimpleMath",Namespace ="http://learningwcf.com/MathService")]
    public interface IMath {

        [OperationContract(Name ="add")]
        double Add(double x, double y);
        //[operationcontract(name = "addlist")]
        //double add(list<double> numbers);
        //---one way demo------
        [OperationContract(Name = "addList", IsOneWay = true)]
        void Add(List<double> numbers);
        [OperationContract(Name = "sub")]
        double Subtract(double x, double y);
        [OperationContract(Name = "mul")]
        double Multiplication(double x, double y);
        [OperationContract(Name = "div")]
        double Division(double x, double y);
        //-----Generic Demo--------
        [OperationContract]
        Message CatchAll(Message input);
    }

    public class MathService : IMath
    {
        //public double Add(List<double> numbers)
        public void Add(List<double> numbers)
        {
            //return numbers.Sum();
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine($"AddList Result {numbers.Sum()}");
        }

        public double Add(double x, double y)
        {
            return x+ y;
        }

        public double Division(double x, double y)
        {
            return x/y;
        }

        public double Multiplication(double x, double y)
        {
           return x * y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }
        public Message CatchAll(Message input)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(input.GetReaderAtBodyContents());
            Console.WriteLine(doc.InnerXml);

            throw new FaultException("You Called a Unsupported Operation");

        }
    }
}
