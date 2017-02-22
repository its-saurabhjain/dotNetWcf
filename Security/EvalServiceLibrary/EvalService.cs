using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    //[MyErrorHandler]
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults =true)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        List<Eval> evalList = new List<Eval>();
        int evalCount = 0;
        public List<Eval> GetEvals()
        {
            //List<Eval> evalList = new List<Eval>();

           return evalList;

        }
        //[PrincipalPermission(SecurityAction.Demand, Role ="BLRIDCLTP16577\\EvalUser")]
        //[OperationBehavior(Impersonation =ImpersonationOption.Required)]
        public void SubmitEvals(Eval eval)
        {
            Console.WriteLine($"Caller Identity {ServiceSecurityContext.Current.PrimaryIdentity.Name}");
            Console.WriteLine($" Service received from : {eval.Submitter} at {eval.Timespent}");
            //code commented for serviceauthorization behavior
            //if (!this.AuthorizeCaller())
            //{
            //    throw new FaultException("Access Denied......didnot provide the correct claim set");

            //}
            //to demo impersonation and claim based authorization
            using (FileStream fs = new FileStream(string.Format("{0}.xml", Guid.NewGuid().ToString()), FileMode.Create, FileAccess.Write))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(Eval));
                dcs.WriteObject(fs, eval);
            }
            eval.evalid = (+evalCount).ToString();
            evalList.Add(eval);
        }

        private bool AuthorizeCaller()
        {
            ServiceSecurityContext ctx = ServiceSecurityContext.Current;
            foreach(ClaimSet cs in ctx.AuthorizationContext.ClaimSets)
            {
                foreach (Claim c in cs)
                {
                    Console.WriteLine($"{c.ClaimType}--{c.Right}--{c.Resource}");
                    if (c.ClaimType.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid") &&
                        c.Right.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/right/processproperty") &&
                        c.Resource.ToString().Equals("S-1-5-21-3152948323-4107609205-1759555066-1007"))
                        return true;
                }
            }
            return false;
        }
    }
}
