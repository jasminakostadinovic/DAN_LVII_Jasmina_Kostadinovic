using Client.ServiceReferenceArticle;
using Model.Models;
using Model.Serializers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var store = new Store();

                if (!File.Exists(ArticlesFile.articlesPath))
                {
                    var newArticles = new string[]
                    {
                        DataSerialization.Serialize(new Article("Soap", 5, 1.99M)),
                        DataSerialization.Serialize(new Article("Shampoo", 10, 5.99M)),
                             DataSerialization.Serialize( new Article("Shower gel", 1, 4.99M))
                    };
                  
                    using (ServiceArticleClient articleService = new ServiceArticleClient())
                    {
                        articleService.TryWriteAllArticles(newArticles);
                    }
                }

                string[] serializedArticles;
                using (ServiceArticleClient articleService = new ServiceArticleClient())
                {
                    serializedArticles = articleService.GetAllArticles();
                }
                foreach (var item in serializedArticles)
                {
                    store.Articles.Add((Article)DataSerialization.Deserialize(item, typeof(Article)));
                }
               
            }
            catch (Exception e)
            {

            }
        }
    }
}
