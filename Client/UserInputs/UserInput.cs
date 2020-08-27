using System;

namespace Client.UserInputs
{
    class UserInput
    {
        public static string GetNameOfArticle()
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                Console.WriteLine($"Enter the name of the article:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                if (string.IsNullOrWhiteSpace(consoleInput))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        public static string GetPriceOfArticle()
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                Console.WriteLine($"Enter the price of the article:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                decimal result;
                if (!decimal.TryParse(consoleInput, out result) 
                    || result <= 0)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        public static string GetQuantityOfArticle()
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                Console.WriteLine($"Enter the quantity of the article:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                int result;
                if (!int.TryParse(consoleInput, out result)
                    || result < 0)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        public static string GetSerialNumberOfArticle(int count)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                Console.WriteLine($"Enter the serial number of the article:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                int result;
                if (!int.TryParse(consoleInput, out result)
                    || result < 1 
                    || result > count)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        internal static string GetCountOfArticle(int remainingQuantity)
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                Console.WriteLine($"Enter the number of items:");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                int result;
                if (!int.TryParse(consoleInput, out result)
                    || result < 1)
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                if(result > remainingQuantity)
                {
                    Console.WriteLine($"Maximum number of items is {remainingQuantity}. Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }

        internal static string GetOption()
        {
            string consoleInput;
            bool shouldRepeat;
            do
            {
                shouldRepeat = false;
                Console.WriteLine(">>>To get back to the menu press '#' + ENTER<<<");
                consoleInput = Console.ReadLine();
                if (consoleInput == "#")
                    continue;
                if (string.IsNullOrWhiteSpace(consoleInput)
                    || (consoleInput != "1" && consoleInput != "2"))
                {
                    Console.WriteLine("Wrong input! Please try again.");
                    shouldRepeat = true;
                    continue;
                }
                shouldRepeat = false;
            } while (shouldRepeat);
            return consoleInput;
        }
    }
}
