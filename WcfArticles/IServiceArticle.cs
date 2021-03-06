﻿using System.ServiceModel;

namespace WcfArticles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceArticle
    {
        [OperationContract]
        string[] GetAllArticles();

        [OperationContract]
        bool TryWriteAllArticles(string[] articles);

        [OperationContract]
        bool TryCreateNewBill(string bill);
    }
}
