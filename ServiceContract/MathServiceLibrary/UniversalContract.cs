using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceLibrary
{
    [ServiceContract]
    public interface IUniversalOneWay {

        [OperationContract(Action = "*", IsOneWay = true)]
        void ProcessMessage(Message msg);
    }

    [ServiceContract]
    public interface IUniversalTwoWay
    {

        [OperationContract(Action = "*", ReplyAction = "*")]
        Message ProcessMessage(Message msg);
    }
}
