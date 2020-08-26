using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool TryUpdateArticlePrice(string id, decimal price)
        {
            var articleToUpdate = Articles.FirstOrDefault(x => x.Id == id);
            if (articleToUpdate != null)
            {
                articleToUpdate.UpdateArticlePrice(price);
                return true;
            }
            return false;
        }
        #endregion
    }
}
