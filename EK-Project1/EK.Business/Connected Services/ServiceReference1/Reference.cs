﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    public class ArrayOfString : System.Collections.Generic.List<string>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AttachmentFile", Namespace="http://tempuri.org/")]
    public partial class AttachmentFile : object
    {
        
        private byte[] documentField;
        
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public byte[] document
        {
            get
            {
                return this.documentField;
            }
            set
            {
                this.documentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AttachmentFileEuromsg", Namespace="http://tempuri.org/")]
    public partial class AttachmentFileEuromsg : object
    {
        
        private string NameField;
        
        private string TypeField;
        
        private string ContentField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                this.TypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                this.ContentField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.MailServicesSoap")]
    public interface MailServicesSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendMailByMsgId", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.SendMailByMsgIdResponse> SendMailByMsgIdAsync(ServiceReference1.SendMailByMsgIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendMail", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.SendMailResponse> SendMailAsync(ServiceReference1.SendMailRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendMailEuromsg", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference1.SendMailEuromsgResponse> SendMailEuromsgAsync(ServiceReference1.SendMailEuromsgRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailByMsgIdRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMailByMsgId", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailByMsgIdRequestBody Body;
        
        public SendMailByMsgIdRequest()
        {
        }
        
        public SendMailByMsgIdRequest(ServiceReference1.SendMailByMsgIdRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailByMsgIdRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string profileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string user;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int msgID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string from;
        
        public SendMailByMsgIdRequestBody()
        {
        }
        
        public SendMailByMsgIdRequestBody(string profileName, string user, int msgID, string from)
        {
            this.profileName = profileName;
            this.user = user;
            this.msgID = msgID;
            this.from = from;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailByMsgIdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMailByMsgIdResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailByMsgIdResponseBody Body;
        
        public SendMailByMsgIdResponse()
        {
        }
        
        public SendMailByMsgIdResponse(ServiceReference1.SendMailByMsgIdResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailByMsgIdResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool SendMailByMsgIdResult;
        
        public SendMailByMsgIdResponseBody()
        {
        }
        
        public SendMailByMsgIdResponseBody(bool SendMailByMsgIdResult)
        {
            this.SendMailByMsgIdResult = SendMailByMsgIdResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMail", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailRequestBody Body;
        
        public SendMailRequest()
        {
        }
        
        public SendMailRequest(ServiceReference1.SendMailRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string profileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string body;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public ServiceReference1.ArrayOfString toList;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public ServiceReference1.ArrayOfString ccList;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public ServiceReference1.ArrayOfString bccList;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public bool isHtml;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string userId;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public bool isSave;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public ServiceReference1.AttachmentFile[] attachmentList;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string from;
        
        public SendMailRequestBody()
        {
        }
        
        public SendMailRequestBody(string profileName, string subject, string body, ServiceReference1.ArrayOfString toList, ServiceReference1.ArrayOfString ccList, ServiceReference1.ArrayOfString bccList, bool isHtml, string userId, bool isSave, ServiceReference1.AttachmentFile[] attachmentList, string from)
        {
            this.profileName = profileName;
            this.subject = subject;
            this.body = body;
            this.toList = toList;
            this.ccList = ccList;
            this.bccList = bccList;
            this.isHtml = isHtml;
            this.userId = userId;
            this.isSave = isSave;
            this.attachmentList = attachmentList;
            this.from = from;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMailResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailResponseBody Body;
        
        public SendMailResponse()
        {
        }
        
        public SendMailResponse(ServiceReference1.SendMailResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool SendMailResult;
        
        public SendMailResponseBody()
        {
        }
        
        public SendMailResponseBody(bool SendMailResult)
        {
            this.SendMailResult = SendMailResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailEuromsgRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMailEuromsg", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailEuromsgRequestBody Body;
        
        public SendMailEuromsgRequest()
        {
        }
        
        public SendMailEuromsgRequest(ServiceReference1.SendMailEuromsgRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailEuromsgRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string FromName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string FromAddress;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ReplyAddress;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Subject;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string HtmlBody;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string ToName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string ToEmailAddress;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public ServiceReference1.AttachmentFileEuromsg[] Attachments;
        
        public SendMailEuromsgRequestBody()
        {
        }
        
        public SendMailEuromsgRequestBody(string FromName, string FromAddress, string ReplyAddress, string Subject, string HtmlBody, string ToName, string ToEmailAddress, ServiceReference1.AttachmentFileEuromsg[] Attachments)
        {
            this.FromName = FromName;
            this.FromAddress = FromAddress;
            this.ReplyAddress = ReplyAddress;
            this.Subject = Subject;
            this.HtmlBody = HtmlBody;
            this.ToName = ToName;
            this.ToEmailAddress = ToEmailAddress;
            this.Attachments = Attachments;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SendMailEuromsgResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SendMailEuromsgResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference1.SendMailEuromsgResponseBody Body;
        
        public SendMailEuromsgResponse()
        {
        }
        
        public SendMailEuromsgResponse(ServiceReference1.SendMailEuromsgResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SendMailEuromsgResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool SendMailEuromsgResult;
        
        public SendMailEuromsgResponseBody()
        {
        }
        
        public SendMailEuromsgResponseBody(bool SendMailEuromsgResult)
        {
            this.SendMailEuromsgResult = SendMailEuromsgResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface MailServicesSoapChannel : ServiceReference1.MailServicesSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class MailServicesSoapClient : System.ServiceModel.ClientBase<ServiceReference1.MailServicesSoap>, ServiceReference1.MailServicesSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MailServicesSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(MailServicesSoapClient.GetBindingForEndpoint(endpointConfiguration), MailServicesSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailServicesSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MailServicesSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailServicesSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MailServicesSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.SendMailByMsgIdResponse> ServiceReference1.MailServicesSoap.SendMailByMsgIdAsync(ServiceReference1.SendMailByMsgIdRequest request)
        {
            return base.Channel.SendMailByMsgIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.SendMailByMsgIdResponse> SendMailByMsgIdAsync(string profileName, string user, int msgID, string from)
        {
            ServiceReference1.SendMailByMsgIdRequest inValue = new ServiceReference1.SendMailByMsgIdRequest();
            inValue.Body = new ServiceReference1.SendMailByMsgIdRequestBody();
            inValue.Body.profileName = profileName;
            inValue.Body.user = user;
            inValue.Body.msgID = msgID;
            inValue.Body.from = from;
            return ((ServiceReference1.MailServicesSoap)(this)).SendMailByMsgIdAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.SendMailResponse> ServiceReference1.MailServicesSoap.SendMailAsync(ServiceReference1.SendMailRequest request)
        {
            return base.Channel.SendMailAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.SendMailResponse> SendMailAsync(string profileName, string subject, string body, ServiceReference1.ArrayOfString toList, ServiceReference1.ArrayOfString ccList, ServiceReference1.ArrayOfString bccList, bool isHtml, string userId, bool isSave, ServiceReference1.AttachmentFile[] attachmentList, string from)
        {
            ServiceReference1.SendMailRequest inValue = new ServiceReference1.SendMailRequest();
            inValue.Body = new ServiceReference1.SendMailRequestBody();
            inValue.Body.profileName = profileName;
            inValue.Body.subject = subject;
            inValue.Body.body = body;
            inValue.Body.toList = toList;
            inValue.Body.ccList = ccList;
            inValue.Body.bccList = bccList;
            inValue.Body.isHtml = isHtml;
            inValue.Body.userId = userId;
            inValue.Body.isSave = isSave;
            inValue.Body.attachmentList = attachmentList;
            inValue.Body.from = from;
            return ((ServiceReference1.MailServicesSoap)(this)).SendMailAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.SendMailEuromsgResponse> ServiceReference1.MailServicesSoap.SendMailEuromsgAsync(ServiceReference1.SendMailEuromsgRequest request)
        {
            return base.Channel.SendMailEuromsgAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.SendMailEuromsgResponse> SendMailEuromsgAsync(string FromName, string FromAddress, string ReplyAddress, string Subject, string HtmlBody, string ToName, string ToEmailAddress, ServiceReference1.AttachmentFileEuromsg[] Attachments)
        {
            ServiceReference1.SendMailEuromsgRequest inValue = new ServiceReference1.SendMailEuromsgRequest();
            inValue.Body = new ServiceReference1.SendMailEuromsgRequestBody();
            inValue.Body.FromName = FromName;
            inValue.Body.FromAddress = FromAddress;
            inValue.Body.ReplyAddress = ReplyAddress;
            inValue.Body.Subject = Subject;
            inValue.Body.HtmlBody = HtmlBody;
            inValue.Body.ToName = ToName;
            inValue.Body.ToEmailAddress = ToEmailAddress;
            inValue.Body.Attachments = Attachments;
            return ((ServiceReference1.MailServicesSoap)(this)).SendMailEuromsgAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.MailServicesSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.MailServicesSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.MailServicesSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://gvywsussrv:8083/MailServices.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.MailServicesSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://gvywsussrv:8083/MailServices.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            MailServicesSoap,
            
            MailServicesSoap12,
        }
    }
}
