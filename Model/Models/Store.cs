using Model.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Store
    {
        public Store()
        {
            Articles = new List<Article>();
        }

        public List<Article> Articles { get; set; }

        #region Methods
        public void ShowAllArticles()
        {
            int counter = 0;
            foreach (var item in Articles)
                Console.WriteLine($"{++counter}. {item.ToString()}");
        }

        public void AddDeserializedArticles(string[] serializedArticles)
        {
            foreach (var item in serializedArticles)
            {
                Articles.Add((Article)DataSerialization.Deserialize(item, typeof(Article)));
            }
        }
        public bool TryCreateNewArticle(Article article)
        {
            try
            {
                Articles.Add(article);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryUpdateArticlePrice(int index, decimal price)
        {
            try
            {
                var articleToUpdate = Articles[index];
                articleToUpdate.UpdateArticlePrice(price);
                return true;
            }
            catch (Exception)
            {
                return false;
            }          
           
        }

        public string[] SerializeArticles()
        {
            var serializedArticles = new string[Articles.Count];
            for (int i = 0; i < Articles.Count; i++)
            {
                serializedArticles[i] = DataSerialization.Serialize(Articles[i]);
            }
            return serializedArticles;
        }

        public override string ToString()
        {
            var count = 0;
            var sb = new StringBuilder();
            foreach (var item in Articles)
            {
                sb.AppendLine($"{++count}. {item.ToString()}");
            }
            return sb.ToString();
        }
        #endregion
    }
}
