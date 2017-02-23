using Sender.ChatServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatClient client = new ChatClient("WSHttpBinding_IChat");
            ChatMessage msg = new ChatMessage();
            msg.UserName = "Saurabh";
            msg.Comment = "Hello";
            using (TransactionScope tx = new TransactionScope())
            {
                client.SendMessage(msg);
                tx.Complete();
            }

            Console.WriteLine("Message Sent...................");
            Console.ReadLine();
        }
    }
}
