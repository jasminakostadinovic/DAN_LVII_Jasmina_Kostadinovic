using Model.Models;
using System;
using System.IO;

namespace WcfArticles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceArticle : IServiceArticle
    {
        
        string articlesPath = AppDomain.CurrentDomain.BaseDirectory + @"\Articles.txt";
        public string[] GetAllArticles()
        {
            try
            {
                if (!File.Exists(articlesPath))
                    return null;
                return File.ReadAllLines(articlesPath);  
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool TryWriteAllArticles(string[] articles)
        {
            try
            {
                File.WriteAllLines(articlesPath, articles);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
