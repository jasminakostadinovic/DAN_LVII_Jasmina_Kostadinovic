using Client.ServiceReferenceArticle;

namespace Client.FileOperations
{
    class FileAccess
    {
        public static void UpdateFile(string[] articles)
        {
            using (ServiceArticleClient articleService = new ServiceArticleClient())
            {
                articleService.TryWriteAllArticles(articles);
            }
        }

        public static string[] LoadFromFile()
        {
            string[] serializedArticles;
            using (ServiceArticleClient articleService = new ServiceArticleClient())
            {
                serializedArticles = articleService.GetAllArticles();
            }
            return serializedArticles;
        }
    }
}
