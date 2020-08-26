using Model.Models;
using System;
using System.IO;

namespace WcfArticles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceArticle : IServiceArticle
    {
        public string[] GetAllArticles()
        {
            try
            {
                return File.ReadAllLines(ArticlesFile.articlesPath);  
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool TryWriteAllArticles(string[] articles)
        {
            try
            {
                File.WriteAllLines(ArticlesFile.articlesPath, articles);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
