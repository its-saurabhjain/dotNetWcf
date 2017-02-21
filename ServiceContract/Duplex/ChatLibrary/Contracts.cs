using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://learningwcf.com/chat")]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]void SendMessage(ChatMessage msg);
    }


    [ServiceContract(Namespace = "http://learningwcf.com/chat",CallbackContract =typeof(IChat))]
    public interface IChatManager
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string name);
        [OperationContract(IsOneWay = true)]
        void SubmitMessage(ChatMessage msg);
    }

    [DataContract(Namespace = "http://learningwcf.com/chat")]
    public class ChatMessage{

        public ChatMessage() { }
        public ChatMessage(string name, DateTime ts, string message)
        {
            this.Name = name;
            this.Timestamp = ts;
            this.message = message;
        }
        [DataMember]
        public string Name;
        [DataMember]
        public DateTime Timestamp;
        [DataMember]public string message;
    
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatManagerService : IChatManager
    {
        Dictionary<string, IChat> clientList = new Dictionary<string, IChat>();
        public void RegisterClient(string name)
        {
            IChat client = OperationContext.Current.GetCallbackChannel<IChat>();
            if (null != client)
                clientList.Add(name, client);
            Console.WriteLine($"{name} Joined.....");
        }

        public void SubmitMessage(ChatMessage msg)
        {
            foreach (string key in clientList.Keys)
            {
                try
                {
                    if (!msg.Name.Equals(key))
                        clientList[key].SendMessage(msg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
