using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
//Main Namespace for DataContractSerialization
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvalServiceLibrary
{
    [DataContract(Name ="Evaluation", Namespace ="http://learningwcf.com/serialization/evals")]
    public class Eval
    {
        public string evalid; //even private field can be in o/p if it is marked with [DataMember] attribute
        [DataMember(Name ="From",IsRequired =false)]
        public string Submitter;
        [DataMember]
        public string Timespent;
        [DataMember(Name= "What", EmitDefaultValue =false)]
        public string Comments;
        [OnDeserialized]
        private void FixUp(StreamingContext ctx)
        {

            if (this.Comments == null)
                this.Comments = "This is from the deserialized FixUp";
        }

    }
   
}
