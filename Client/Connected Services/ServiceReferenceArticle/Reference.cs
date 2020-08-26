﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReferenceArticle {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceArticle.IServiceArticle")]
    public interface IServiceArticle {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceArticle/GetAllArticles", ReplyAction="http://tempuri.org/IServiceArticle/GetAllArticlesResponse")]
        string[] GetAllArticles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceArticle/GetAllArticles", ReplyAction="http://tempuri.org/IServiceArticle/GetAllArticlesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllArticlesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceArticle/TryWriteAllArticles", ReplyAction="http://tempuri.org/IServiceArticle/TryWriteAllArticlesResponse")]
        bool TryWriteAllArticles(string[] articles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceArticle/TryWriteAllArticles", ReplyAction="http://tempuri.org/IServiceArticle/TryWriteAllArticlesResponse")]
        System.Threading.Tasks.Task<bool> TryWriteAllArticlesAsync(string[] articles);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceArticleChannel : Client.ServiceReferenceArticle.IServiceArticle, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceArticleClient : System.ServiceModel.ClientBase<Client.ServiceReferenceArticle.IServiceArticle>, Client.ServiceReferenceArticle.IServiceArticle {
        
        public ServiceArticleClient() {
        }
        
        public ServiceArticleClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceArticleClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceArticleClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceArticleClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetAllArticles() {
            return base.Channel.GetAllArticles();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllArticlesAsync() {
            return base.Channel.GetAllArticlesAsync();
        }
        
        public bool TryWriteAllArticles(string[] articles) {
            return base.Channel.TryWriteAllArticles(articles);
        }
        
        public System.Threading.Tasks.Task<bool> TryWriteAllArticlesAsync(string[] articles) {
            return base.Channel.TryWriteAllArticlesAsync(articles);
        }
    }
}
