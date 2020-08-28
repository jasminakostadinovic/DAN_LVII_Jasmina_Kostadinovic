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
                        Console.WriteLine(store.PrintArticles(store.Articles));

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
                        FileOperations.FileAccess.UpdateFileArticles(store.SerializeArticles());

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
                        Console.WriteLine(store.PrintArticles(store.Articles));
                        //getting values from the user
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
                        //updating the store
                        if (store.TryUpdateArticlePrice(index, decimal.Parse(consoleInputForNewArticlePrice)))
                        {
                            //updating the file
                            FileOperations.FileAccess.UpdateFileArticles(store.SerializeArticles());
                            Console.WriteLine("You have successfully updated the price of the article.");
                        }                         
                        else
                            Console.WriteLine("Something went wrong. Price is not updated.");
                        shouldRepeat = true;
                        continue;
                    case 4:
                        var purchasedItems = new List<(int, Article)>();
                        var storeCopy = new Store(store);
                        Again:
                        var availableArticles = storeCopy.GetAvailableArticles();
                        //checking if there are available articles in the store
                        if (!availableArticles.Any())
                        {
                            Console.WriteLine("There are no available articles to be purchased.");
                            if (purchasedItems.Any())
                                goto Complete;
                            shouldRepeat = true;
                            continue;
                        }
                        Console.WriteLine(storeCopy.PrintArticles(availableArticles));

                        var consoleInputForSerialNo = UserInput.GetSerialNumberOfArticle(availableArticles.Count);
                        if (consoleInputForSerialNo == "#")
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        int indexOfArticle = int.Parse(consoleInputForSerialNo) - 1;
                        var article = availableArticles[indexOfArticle];
                        var consoleInputForArticlesCount = UserInput.GetCountOfArticle(article.RemainingQuantity);
                        if (consoleInputForArticlesCount == "#")
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        var newQuantity = article.RemainingQuantity - int.Parse(consoleInputForArticlesCount);

                        string idOfArticle = availableArticles[indexOfArticle].Id;

                        storeCopy.TryUpdateArticleRemainingQuantity(idOfArticle, newQuantity);
                        purchasedItems.Add((int.Parse(consoleInputForArticlesCount), article));

                        Console.WriteLine("To continue purchase press '1'. To complete the purchase press '2'.");
                        var consoleInputForOption = UserInput.GetOption();
                        if (consoleInputForOption == "#")
                        {
                            shouldRepeat = true;
                            continue;
                        }
                        if (consoleInputForOption == "2")
                            goto Complete;
                        else
                            goto Again;

                        Complete:

                        var bill = store.GenerateBill(purchasedItems);
                        if (FileOperations.FileAccess.TryCreateNewBillFile(bill))
                        {
                            //updating the file
                            store = storeCopy;
                            FileOperations.FileAccess.UpdateFileArticles(store.SerializeArticles());
                            Console.WriteLine("You have successfully finished your purchased.");
                            Console.WriteLine(bill);
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. Bill is not created.");
                        }

                        shouldRepeat = true;
                        continue;
                    case 5:
                        //exiting the app
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
