﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecurityClient.EvalLibServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Evaluation", Namespace="http://learningwcf.com/serialization/evals")]
    [System.SerializableAttribute()]
    public partial class Evaluation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TimespentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WhatField;
        
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
        public string From {
            get {
                return this.FromField;
            }
            set {
                if ((object.ReferenceEquals(this.FromField, value) != true)) {
                    this.FromField = value;
                    this.RaisePropertyChanged("From");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Timespent {
            get {
                return this.TimespentField;
            }
            set {
                if ((object.ReferenceEquals(this.TimespentField, value) != true)) {
                    this.TimespentField = value;
                    this.RaisePropertyChanged("Timespent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string What {
            get {
                return this.WhatField;
            }
            set {
                if ((object.ReferenceEquals(this.WhatField, value) != true)) {
                    this.WhatField = value;
                    this.RaisePropertyChanged("What");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EvalLibServiceReference.IEvalService")]
    public interface IEvalService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/SubmitEvals", ReplyAction="http://tempuri.org/IEvalService/SubmitEvalsResponse")]
        void SubmitEvals(SecurityClient.EvalLibServiceReference.Evaluation eval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/SubmitEvals", ReplyAction="http://tempuri.org/IEvalService/SubmitEvalsResponse")]
        System.Threading.Tasks.Task SubmitEvalsAsync(SecurityClient.EvalLibServiceReference.Evaluation eval);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/GetEvals", ReplyAction="http://tempuri.org/IEvalService/GetEvalsResponse")]
        System.Collections.Generic.List<SecurityClient.EvalLibServiceReference.Evaluation> GetEvals();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEvalService/GetEvals", ReplyAction="http://tempuri.org/IEvalService/GetEvalsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SecurityClient.EvalLibServiceReference.Evaluation>> GetEvalsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEvalServiceChannel : SecurityClient.EvalLibServiceReference.IEvalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EvalServiceClient : System.ServiceModel.ClientBase<SecurityClient.EvalLibServiceReference.IEvalService>, SecurityClient.EvalLibServiceReference.IEvalService {
        
        public EvalServiceClient() {
        }
        
        public EvalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EvalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EvalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EvalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SubmitEvals(SecurityClient.EvalLibServiceReference.Evaluation eval) {
            base.Channel.SubmitEvals(eval);
        }
        
        public System.Threading.Tasks.Task SubmitEvalsAsync(SecurityClient.EvalLibServiceReference.Evaluation eval) {
            return base.Channel.SubmitEvalsAsync(eval);
        }
        
        public System.Collections.Generic.List<SecurityClient.EvalLibServiceReference.Evaluation> GetEvals() {
            return base.Channel.GetEvals();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SecurityClient.EvalLibServiceReference.Evaluation>> GetEvalsAsync() {
            return base.Channel.GetEvalsAsync();
        }
    }
}
