using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length >0 && args[0].Equals("-d"))
                Deserialize();
            else
                Serialize();
        }
        
        private static void Deserialize()
        {
            using (FileStream fso = new FileStream("eval.xml", FileMode.Open))
            {
                //XmlSerializer xcs = new XmlSerializer(typeof(Eval));
                //Eval eval = xcs.Deserialize(fso) as Eval;
                //Console.WriteLine($"Submitter: {eval.Submitter}, at {eval.Timespent}");
                DataContractSerializer dcs = new DataContractSerializer(typeof(Eval));
                Eval eval = dcs.ReadObject(fso) as Eval;
                if (eval is DetailedEval)
                {
                    DetailedEval de = eval as DetailedEval;
                    Console.WriteLine($"Detailed Eval Submitter: {de.Submitter}, at {de.Timespent} and additional comment {de.AdditionalComment}");

                }

                Console.WriteLine($"Submitter: {eval.Submitter}, {eval.Comments} at {eval.Timespent}");
            }

        }

        private static void Serialize()
        {
            /*
            Eval eval = new Eval();
            eval.Submitter = "Saurabh";
            eval.Timespent = DateTime.Now.ToString();
            eval.Comments = "This is Serialization....";
            eval.post = new Post() {PostComments = "These are post comments" };
            */
            DetailedEval eval = new DetailedEval();
            eval.Submitter = "Saurabh";
            eval.Timespent = DateTime.Now.ToString();
            //eval.Comments = "This is Serialization....";
            eval.AdditionalComment = "These are additional comments";
            eval.post = new Post() { PostComments = "These are post comments" };
            //eval.Questions = new System.Data.DataSet();
            eval.Questions = new List<QuestionRating>();
            QuestionRating q1;
            q1 = new QuestionRating() { QuestionText = "This is question1", Ratings = 1 };
            eval.Questions.Add(q1);
            q1 = new QuestionRating() { QuestionText = "This is question2", Ratings = 2 };
            eval.Questions.Add(q1);
            //use stream
            using (FileStream fso = new FileStream("eval.xml", FileMode.Create))
            {
                /*XmlSer willnot create outputs for private fields as well...only public visible*/
                //XmlSerializer xcs = new XmlSerializer(typeof(Eval));
                //xcs.Serialize(fso, eval);
                /*NetDataContract will create outputs for private fields as well...*/
                //NetDataContractSerializer ndcs = new NetDataContractSerializer();
                //ndcs.Serialize(fso, eval);
                DataContractSerializer dcs = new DataContractSerializer(typeof(Eval));
                dcs.WriteObject(fso, eval);
            }
            
        }
    }
}
