using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    public class CustomErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            Console.WriteLine("IErrorHandler.HandleError was called");
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            fault = Message.CreateMessage(version, 
                                    FaultCode.CreateSenderFaultCode("BadEvalSubmission","http://learningwcf.com/evals"),
                                    "Bad Eval Submitted (IErrorHandler)",
                                    new BadEvalSubmission(),
                                    "http://learningwcf.com/IEvalService/SubmitEvalBadEvalSubmissionFault");
        }
    }
    public class MyErrorHandlerAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
                cd.ErrorHandlers.Add(new CustomErrorHandler());
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }
    }
}
