using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MultipleServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyService : IFoo, IBar, IBaz
    {
        public string SayGoodBye(string name)
        {
            return String.Format("Good Bye {0} !..", name);
        }

        public string SayHello(string name)
        {
            return String.Format("Hello {0} !--", name);
        }

        public string SaySomethingNice(string name)
        {
            return String.Format("{0} is Cool!..", name);
        }
    }
}
