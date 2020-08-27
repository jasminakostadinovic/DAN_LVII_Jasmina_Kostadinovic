using Client.UserInputs;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Menus
{
    class MainMenu
    {
        private Store store;

        public MainMenu(Store store)
        {
            this.store = store;
        }

        public void CreateMenu()
        {
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Show all articles\n2. Add new article\n3. Update the price of the article\n4. Make a purchase\n5. Exit\n");
                string input = Console.ReadLine();
                //Validation of the user input so the app won't crash if the input is wrong
                if (!int.TryParse(input, out int inputNumber) || char.IsWhiteSpace(input[0]))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                switch (inputNumber)
                {
                    case 1:                          
                            if (!store.Articles.Any())
                            {
                                Console.WriteLine("There are no available articles to be shown.");
                                shouldRepeat = true;
                                continue;
                            }
                        Console.WriteLine(store.ToString());    
                   
                        shouldRepeat = true;
                        continue;
                    case 2:
                        //getting values from the user
                            var consoleInputForArticleName = UserInput.GetNameOfArticle();
                            if (consoleInputForArticleName == "#")
                            {
                                shouldRepeat = true;
                                continue;
                            }
                            var consoleInputForArticlePrice = UserInput.GetPriceOfArticle();
                            if (consoleInputForArticlePrice == "#")
                            {
                                shouldRepeat = true;
                                continue;
                            }

                            var consoleInputForArticleQuantity = UserInput.GetQuantityOfArticle();
                            if (consoleInputForArticleQuantity == "#")
                            {
                                shouldRepeat = true;
                                continue;
                            }

                            var newArticle = new Article(consoleInputForArticleName, int.Parse(consoleInputForArticleQuantity), decimal.Parse(consoleInputForArticlePrice));
                            store.Articles.Add(newArticle);
                            //updating the file
                            FileOperations.FileAccess.UpdateFile(store.SerializeArticles());

                        Console.WriteLine("You have successfully created the new article.");
                     
                        shouldRepeat = true;
                        continue;
                    case 3:
                        //checking if there are available articles in the store
                        if (!store.Articles.Any())
                        {
                            Console.WriteLine("There are no available articles to be updated.");
                            shouldRepeat = true;
                            continue;
                        }
                        Console.WriteLine(store.ToString());
                        var consoleInputForSerialNumber = UserInput.GetSerialNumberOfArticle(store.Articles.Count);
                        if (consoleInputForSerialNumber == "#")
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        var consoleInputForNewArticlePrice = UserInput.GetPriceOfArticle();
                        if (consoleInputForNewArticlePrice == "#")
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        int index = int.Parse(consoleInputForSerialNumber) - 1;
                        if(store.TryUpdateArticlePrice(index, decimal.Parse(consoleInputForNewArticlePrice)))
                            Console.WriteLine("You have successfully updated the price of the article.");
                        else
                            Console.WriteLine("Something went wrong. Price is not updated.");
                        shouldRepeat = true;
                        continue;
                    case 4:
                     
                        shouldRepeat = true;
                        continue;
                    case 5:
                     
                        shouldRepeat = false;
                        continue;
                    default:
                        Console.WriteLine("Wrong input! Please try again.");
                        shouldRepeat = true;
                        break;
                }
            } while (shouldRepeat);
        }       
    }
}
