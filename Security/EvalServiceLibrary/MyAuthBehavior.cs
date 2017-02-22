using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    public class MyAuthBehavior: ServiceAuthorizationManager
    {

        public override bool CheckAccess(OperationContext operationContext)
        {
            ServiceSecurityContext ctx = operationContext.ServiceSecurityContext;
            foreach (ClaimSet cs in ctx.AuthorizationContext.ClaimSets)
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
            return base.CheckAccess(operationContext);
        }
    }
}
