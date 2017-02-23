﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sender.ChatServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatMessage", Namespace="http://schemas.datacontract.org/2004/07/ChatServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class ChatMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeSentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string Comment {
            get {
                return this.CommentField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentField, value) != true)) {
                    this.CommentField = value;
                    this.RaisePropertyChanged("Comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeSent {
            get {
                return this.TimeSentField;
            }
            set {
                if ((this.TimeSentField.Equals(value) != true)) {
                    this.TimeSentField = value;
                    this.RaisePropertyChanged("TimeSent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServiceRef.IChat")]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendMessage", ReplyAction="http://tempuri.org/IChat/SendMessageResponse")]
        [System.ServiceModel.TransactionFlowAttribute(System.ServiceModel.TransactionFlowOption.Mandatory)]
        void SendMessage(Sender.ChatServiceRef.ChatMessage msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/SendMessage", ReplyAction="http://tempuri.org/IChat/SendMessageResponse")]
        System.Threading.Tasks.Task SendMessageAsync(Sender.ChatServiceRef.ChatMessage msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : Sender.ChatServiceRef.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.ClientBase<Sender.ChatServiceRef.IChat>, Sender.ChatServiceRef.IChat {
        
        public ChatClient() {
        }
        
        public ChatClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendMessage(Sender.ChatServiceRef.ChatMessage msg) {
            base.Channel.SendMessage(msg);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(Sender.ChatServiceRef.ChatMessage msg) {
            return base.Channel.SendMessageAsync(msg);
        }
    }
}
