using Client.ServiceReferenceArticle;

namespace Client.FileOperations
{
    class FileAccess
    {
        public static void UpdateFileArticles(string[] articles)
        {
            using (ServiceArticleClient articleService = new ServiceArticleClient())
            {
                articleService.TryWriteAllArticles(articles);
            }
        }

        public static string[] LoadFromFileArticles()
        {
            string[] serializedArticles;
            using (ServiceArticleClient articleService = new ServiceArticleClient())
            {
                serializedArticles = articleService.GetAllArticles();
            }
            return serializedArticles;
        }

        public static bool TryCreateNewBillFile(string bill)
        {
            using (ServiceArticleClient articleService = new ServiceArticleClient())
            {
                return articleService.TryCreateNewBill(bill);
            }
        }
    }
}
