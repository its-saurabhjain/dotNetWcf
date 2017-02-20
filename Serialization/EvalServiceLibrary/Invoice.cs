using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    [Serializable]
    public class Address
    {
        public string Street;
        public string City;
        public string State;
        public string Zip;
    }
    [DataContract]
    public enum CompanyType
    {
        [EnumMember]LLC,
        [EnumMember]SCorp,
        [EnumMember]CCorp
    }
    [DataContract]
    public class Company
    {
        [DataMember]
        public string CompanyName;
        [DataMember]
        public CompanyType Type;
        [DataMember]
        public Address Address;
        ///
        [OnDeserializing]
        void OnDeSerialization(StreamingContext ctx) { }
        [OnDeserialized]
        void OnDeSerialized(StreamingContext ctx) { }
        [OnSerializing]
        void OnSerialization(StreamingContext ctx) { }
        [OnSerialized]
        void OnSerialized(StreamingContext ctx) { }
    }


}
