using Model.Models;
using System;
using System.IO;
using System.Text;

namespace WcfArticles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceArticle : IServiceArticle
    {
        
        string articlesPath = AppDomain.CurrentDomain.BaseDirectory + @"\Articles.txt";
        string billPath = AppDomain.CurrentDomain.BaseDirectory + GenerateBillFileName();
        static int count = 0;
        private static string GenerateBillFileName()
        {
            return $"Racun_{++count}_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}.txt";
        }

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

        public bool TryCreateNewBill(string bill)
        {
            try
            {
                File.WriteAllText(billPath, bill);
                return true;
            }
            catch (Exception)
            {
                return false;
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
