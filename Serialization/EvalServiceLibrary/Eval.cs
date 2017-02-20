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
    //Xml ser will output only publicly visible fields
    //NetDataContract Serializer will output Comments filed even if it is private
    /*
    [Serializable]
    public class Eval
    {
        public string Submitter;
        public string Timespent;
        private string Comments;
        public string EvalId { get; set; }
    }
    */

    [KnownType(typeof(DetailedEval))]
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
        [DataMember(EmitDefaultValue =false)]
        public Post post;
        /*
        [DataMember]public string EvalId
        { get { return evalid; } set { evalid = value; }}
        */
        [OnDeserialized]
        private void FixUp(StreamingContext ctx)
        {

            if (this.Comments == null)
                this.Comments = "This is from the deserialized FixUp";
        }

    }
    
    public class Post
    {
        public Nullable<int> PostId;
        public string PostComments;

    }

    [DataContract(Namespace = "http://learningwcf.com/serialization/evals")]
    public class DetailedEval: Eval
    {
        [DataMember(Name ="additional")]
        public string AdditionalComment;
        [DataMember]
        //public DataSet Questions;
        public List<QuestionRating> Questions;
        
    }
    [DataContract(Namespace = "http://learningwcf.com/serialization/evals")]
    public class QuestionRating
    {
        [DataMember]
        public string QuestionText;
        [DataMember]
        public int Ratings;
    }

   
}
