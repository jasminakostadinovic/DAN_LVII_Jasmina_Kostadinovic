﻿using Client.Menus;
using Model.Models;
using System;
using System.IO;
using WcfArticles;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var store = new Store();

                string[] serializedArticles = FileOperations.FileAccess.LoadFromFileArticles();

                if (FileOperations.FileAccess.LoadFromFileArticles() == null)
                {
                    var article1 = new Article("Soap", 5, 1.99M);
                    var article2 = new Article("Shower gel", 1, 4.99M);
                    store.Articles.Add(article1);
                    store.Articles.Add(article2);
                    
                    FileOperations.FileAccess.UpdateFileArticles(store.SerializeArticles()); 
                }
                else  
                    store.AddDeserializedArticles(serializedArticles);

                var mainMenu = new MainMenu(store);
                mainMenu.CreateMenu();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something unexpected happened. Contact the support service for more information...\n");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
