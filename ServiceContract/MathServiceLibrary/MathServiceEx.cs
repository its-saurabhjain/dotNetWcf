using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceLibrary
{
    

    [DataContract]
    public class MathInputs
    {
        [DataMember]
        public double x;
        [DataMember]
        public double y;
    }
    [MessageContract(IsWrapped =false)]
    public class MathRequest
    {
        [MessageBodyMember]public MathInputs mathInputs;
        [MessageHeader]public string UserId;
    }
    [MessageContract(IsWrapped = false)]
    public class MathResponse
    {
        public MathResponse() { }
        public MathResponse(double res) { this.result = res; }
        [MessageBodyMember]
        public double result;
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Name = "SimpleMathEx", Namespace = "http://learningwcf.com/MathService")]
    public interface IMathEx
    {

        [OperationContract(Name = "add")]
        MathResponse Add(MathRequest req);

        [OperationContract(Name = "sub")]
        MathResponse Subtract(MathRequest req);

    }

    public class MathServiceEx : IMathEx
    {
        public MathResponse Add(MathRequest req)
        {
            Console.WriteLine($"Add request was called by {req.UserId}");
            double result = req.mathInputs.x + req.mathInputs.y;
            MathResponse res = new MathResponse(result);
            return res;
        }

        public MathResponse Subtract(MathRequest req)
        {
            Console.WriteLine($"Subtract request was called by {req.UserId}");
            double result = req.mathInputs.x - req.mathInputs.y;
            MathResponse res = new MathResponse(result);
            return res;
        }
    }

}
