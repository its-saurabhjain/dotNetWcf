using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    //[KnownType(typeof(Contact))]
    //[KnownType(typeof(Customer))]
    [KnownType("GetMyKnownType")]
    [Serializable]
    public class Person
    {
        public string Id;
        public string Name;
        static IEnumerable<Type> GetMyKnownTypes()
        {
            List<Type> knownTypes = new List<Type>();
            knownTypes.Add(typeof(Contact));
            knownTypes.Add(typeof(Customer));
            return knownTypes;
        }
    }
    [DataContract]
    public class Contact : Person
    {
        [DataMember]
        public string Phone;
        [DataMember]
        public string Email;
    }
    [DataContract]
    public class Customer : Contact {
        [DataMember]
        public string CustomerId;
    }
}
