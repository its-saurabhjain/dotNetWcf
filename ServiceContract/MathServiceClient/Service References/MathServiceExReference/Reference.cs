﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MathServiceClient.MathServiceExReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MathInputs", Namespace="http://schemas.datacontract.org/2004/07/MathServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class MathInputs : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double xField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double yField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double x {
            get {
                return this.xField;
            }
            set {
                if ((this.xField.Equals(value) != true)) {
                    this.xField = value;
                    this.RaisePropertyChanged("x");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double y {
            get {
                return this.yField;
            }
            set {
                if ((this.yField.Equals(value) != true)) {
                    this.yField = value;
                    this.RaisePropertyChanged("y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://learningwcf.com/MathService", ConfigurationName="MathServiceExReference.SimpleMathEx")]
    public interface SimpleMathEx {
        
        // CODEGEN: Generating message contract since the operation add is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://learningwcf.com/MathService/SimpleMathEx/add", ReplyAction="http://learningwcf.com/MathService/SimpleMathEx/addResponse")]
        MathServiceClient.MathServiceExReference.MathResponse add(MathServiceClient.MathServiceExReference.MathRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://learningwcf.com/MathService/SimpleMathEx/add", ReplyAction="http://learningwcf.com/MathService/SimpleMathEx/addResponse")]
        System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> addAsync(MathServiceClient.MathServiceExReference.MathRequest request);
        
        // CODEGEN: Generating message contract since the operation sub is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://learningwcf.com/MathService/SimpleMathEx/sub", ReplyAction="http://learningwcf.com/MathService/SimpleMathEx/subResponse")]
        MathServiceClient.MathServiceExReference.MathResponse sub(MathServiceClient.MathServiceExReference.MathRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://learningwcf.com/MathService/SimpleMathEx/sub", ReplyAction="http://learningwcf.com/MathService/SimpleMathEx/subResponse")]
        System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> subAsync(MathServiceClient.MathServiceExReference.MathRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MathRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://learningwcf.com/MathService")]
        public string UserId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://learningwcf.com/MathService", Order=0)]
        public MathServiceClient.MathServiceExReference.MathInputs mathInputs;
        
        public MathRequest() {
        }
        
        public MathRequest(string UserId, MathServiceClient.MathServiceExReference.MathInputs mathInputs) {
            this.UserId = UserId;
            this.mathInputs = mathInputs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class MathResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://learningwcf.com/MathService", Order=0)]
        public double result;
        
        public MathResponse() {
        }
        
        public MathResponse(double result) {
            this.result = result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SimpleMathExChannel : MathServiceClient.MathServiceExReference.SimpleMathEx, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimpleMathExClient : System.ServiceModel.ClientBase<MathServiceClient.MathServiceExReference.SimpleMathEx>, MathServiceClient.MathServiceExReference.SimpleMathEx {
        
        public SimpleMathExClient() {
        }
        
        public SimpleMathExClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimpleMathExClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimpleMathExClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimpleMathExClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MathServiceClient.MathServiceExReference.MathResponse MathServiceClient.MathServiceExReference.SimpleMathEx.add(MathServiceClient.MathServiceExReference.MathRequest request) {
            return base.Channel.add(request);
        }
        
        public double add(string UserId, MathServiceClient.MathServiceExReference.MathInputs mathInputs) {
            MathServiceClient.MathServiceExReference.MathRequest inValue = new MathServiceClient.MathServiceExReference.MathRequest();
            inValue.UserId = UserId;
            inValue.mathInputs = mathInputs;
            MathServiceClient.MathServiceExReference.MathResponse retVal = ((MathServiceClient.MathServiceExReference.SimpleMathEx)(this)).add(inValue);
            return retVal.result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> MathServiceClient.MathServiceExReference.SimpleMathEx.addAsync(MathServiceClient.MathServiceExReference.MathRequest request) {
            return base.Channel.addAsync(request);
        }
        
        public System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> addAsync(string UserId, MathServiceClient.MathServiceExReference.MathInputs mathInputs) {
            MathServiceClient.MathServiceExReference.MathRequest inValue = new MathServiceClient.MathServiceExReference.MathRequest();
            inValue.UserId = UserId;
            inValue.mathInputs = mathInputs;
            return ((MathServiceClient.MathServiceExReference.SimpleMathEx)(this)).addAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MathServiceClient.MathServiceExReference.MathResponse MathServiceClient.MathServiceExReference.SimpleMathEx.sub(MathServiceClient.MathServiceExReference.MathRequest request) {
            return base.Channel.sub(request);
        }
        
        public double sub(string UserId, MathServiceClient.MathServiceExReference.MathInputs mathInputs) {
            MathServiceClient.MathServiceExReference.MathRequest inValue = new MathServiceClient.MathServiceExReference.MathRequest();
            inValue.UserId = UserId;
            inValue.mathInputs = mathInputs;
            MathServiceClient.MathServiceExReference.MathResponse retVal = ((MathServiceClient.MathServiceExReference.SimpleMathEx)(this)).sub(inValue);
            return retVal.result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> MathServiceClient.MathServiceExReference.SimpleMathEx.subAsync(MathServiceClient.MathServiceExReference.MathRequest request) {
            return base.Channel.subAsync(request);
        }
        
        public System.Threading.Tasks.Task<MathServiceClient.MathServiceExReference.MathResponse> subAsync(string UserId, MathServiceClient.MathServiceExReference.MathInputs mathInputs) {
            MathServiceClient.MathServiceExReference.MathRequest inValue = new MathServiceClient.MathServiceExReference.MathRequest();
            inValue.UserId = UserId;
            inValue.mathInputs = mathInputs;
            return ((MathServiceClient.MathServiceExReference.SimpleMathEx)(this)).subAsync(inValue);
        }
    }
}