using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MultipleServiceContract
{
    [ServiceContract]public interface IFoo{
        [OperationContract]
        string SayHello(string name);
    }
    [ServiceContract]
    public interface IBar : IFoo{
        [OperationContract]
        string SayGoodBye(string name);
    }
    [ServiceContract]
    public interface IBaz :IBar{
        [OperationContract]
        string SaySomethingNice(string name);
    }
}
