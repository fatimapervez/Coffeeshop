
 using System;

public class Program
    {
        static string[] menu =
        {
        "Coffee",
        "Tea",
        "Sandwich",
        "Cake",
        "Winter Deal",
        "New Year Deal"
    };

        static double[] prices = { 3.0, 2.5, 5.0, 4.0, 6.5, 7.0 };

        static int[] inventory = { 5, 3, 2, 4, 1, 0 };

        static void Main(string[] args)
        {
            CustomerSection();
        }

        public static void CustomerSection()
        {
            Console.WriteLine("WELCOME TO COFFEE SHOP");

            Console.WriteLine("\nHere is our menu:");

            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]} - ${prices[i]}");
            }

            Console.Write("\nEnter item numbers (comma-separated): ");

            string[] items = (Console.ReadLine() ?? "").Split(',');

            double total = 0;
            string orderedItems = "";

            for (int i = 0; i < items.Length; i++)
            {
                int itemNumber;

                if (!int.TryParse(items[i].Trim(), out itemNumber) ||
                    itemNumber < 1 || itemNumber > menu.Length)
                {
                    Console.WriteLine("Invalid item number.");
                    continue;
                }

                int index = itemNumber - 1;

                if (inventory[index] > 0)
                {
                    inventory[index]--;

                    total += prices[index];

                    orderedItems +=
                        $"{menu[index]} - ${prices[index]}\n";
                }
                else
                {
                    Console.WriteLine(
                        $"Sorry, {menu[index]} is out of stock.");
                }
            }

            Console.WriteLine("\nOrdered Items:");
            Console.WriteLine(orderedItems);

            Console.WriteLine($"Total Amount: ${total}");
        }
    }
}

