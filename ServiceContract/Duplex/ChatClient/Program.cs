using ChatLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chat Library.......");
            Console.WriteLine("Please Enter Your Name.......");
            string name = Console.ReadLine();

            ChatService localservice = new ChatService();
            DuplexChannelFactory<IChatManager> dcf =
                            new DuplexChannelFactory<IChatManager>(localservice, "mgr");
            IChatManager chatmgr = dcf.CreateChannel();
            chatmgr.RegisterClient(name);
            Console.WriteLine($"\n Enter message");
            string command = Console.ReadLine();
            while (!command.Equals("exit"))
            {
                chatmgr.SubmitMessage(new ChatMessage(name, DateTime.Now, command));
                command = Console.ReadLine();
            }

            Console.ReadLine();

        }
    }

    public class ChatService : IChat
    {
        public void SendMessage(ChatMessage msg)
        {
            Console.WriteLine($"{msg.Timestamp}: {msg.Name} says {msg.message}");
        }
    }
}
