using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace ChatServiceLibrary
{
    [DataContract]
    public class ChatMessage {

        public ChatMessage() { }
        public ChatMessage(string userName, string comment) {
            this.UserName = userName;
            this.TimeSent = DateTime.Now;
            this.Comment = comment;

        }
        [DataMember] public string UserName;
        [DataMember] public DateTime TimeSent;
        [DataMember]public string Comment;
    }
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IChat
    {
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        [OperationContract] //Transction flow cannot happen over 1 way operation
        //[OperationContract(IsOneWay = true)]
        void SendMessage(ChatMessage msg);
    }


    public class ChatService : IChat
    {
        [OperationBehavior(TransactionScopeRequired =true, TransactionAutoComplete =true)]
        public void SendMessage(ChatMessage msg)
        {
            MessageQueue queue = new MessageQueue(@".\private$\Chat");
            queue.Send(msg, MessageQueueTransactionType.Automatic);
            Console.WriteLine($"{msg.TimeSent}: {msg.UserName} Says {msg.Comment}");
        }
    }
}
