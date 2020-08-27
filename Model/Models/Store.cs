using Model.Serializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Model.Models
{
    public class Store
    {
        public Store(Store store)
        {
            Articles = store.Articles;
        }
        public Store()
        {
            Articles = new List<Article>();
        }

        public List<Article> Articles { get; set; }

        public List<Article> GetAvailableArticles()
        {
            return Articles.Where(x => x.RemainingQuantity > 0).ToList();
        }

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
        public bool TryUpdateArticleRemainingQuantity(string id, int remainingQuantity)
        {
            var articleToUpdate = Articles.FirstOrDefault(x => x.Id == id);
            if (articleToUpdate != null)
            {
                articleToUpdate.UpdateArticleRemainingQuantity(remainingQuantity);
                return true;
            }
            return false;
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

        public string PrintArticles(List<Article> articles)
        {
            var count = 0;
            var sb = new StringBuilder();
            foreach (var item in articles)
            {
                sb.AppendLine($"{++count}. {item.ToString()}");
            }
            return sb.ToString();
        }


        public string GenerateBill(List<(int, Article)> purchasedItems)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now.ToString()}");
            decimal totalSum = 0;
            foreach (var item in purchasedItems)
            {
                sb.AppendLine($"{item.Item2.Name} - {item.Item1} X {item.Item2.Price.ToString("C", CultureInfo.CurrentCulture)}");
                totalSum += item.Item2.Price * item.Item1;
            }
           
            sb.AppendLine($"Total: {totalSum.ToString("C", CultureInfo.CurrentCulture)}");

            return sb.ToString();
        }
        #endregion
    }
}
