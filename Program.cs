

namespace Fruit_Market
{

    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    public class Driver
    {

        public async void Main()
        {
            bool running = true;
            string MenuSelector = "";
            HttpClient httpClient = new HttpClient();
            string UserFruit = "";
            List<string> FruitList = new List<string>();

            Console.WriteLine("Welcome to the fruit market. Select what you would like to do by entering a number: ");

            while (running)
            {
                Console.WriteLine(
                "\n1. Type in a fruit to learn more about it before you purchase it." +
                "\n2. Type in a fruit to add it to your cart." +
                "\n3. View Cart." +
                "\n4. End the program.");

                Console.Write("\n");
                MenuSelector = Console.ReadLine();
                if (MenuSelector == "1")
                {
                    Console.WriteLine("\nEnter the fruit you want to research.");
                    Console.Write("\n");
                    UserFruit = Console.ReadLine();
                    string baseURL = "https://fruityvice.com";
                    string apiURL = $"{baseURL}/api/fruit/{UserFruit}";
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(apiURL);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string apiOutput = await httpResponse.Content.ReadAsStringAsync();
                        Fruit retrievedFruit = JsonSerializer.Deserialize<Fruit>(apiOutput);
                        Console.WriteLine($"Name: {retrievedFruit.name}");
                        Console.WriteLine($"Family: {retrievedFruit.family}");
                        Console.WriteLine($"Genus: {retrievedFruit.genus}");
                        Console.WriteLine($"Order: {retrievedFruit.order}");
                        Console.WriteLine($"Nutritions: ");
                        foreach (var nutrient in retrievedFruit.nutrition)
                        {
                            Console.WriteLine($"{nutrient.Key}: {nutrient.Value}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Fruit not found within system. Please try again");
                    }


                    running = true;
                }
                else if (MenuSelector == "2")
                {
                    Console.WriteLine("\nEnter the fruit you would like to add to cart.");
                    Console.Write("\n");
                    UserFruit = Console.ReadLine();
                    FruitList.Add(UserFruit);
                    Console.WriteLine("\n" + UserFruit + " added to cart.");

                    running = true;
                }
                else if (MenuSelector == "3")
                {
                    Console.WriteLine("\n----------------------------------");
                    foreach (string fruit in FruitList)
                    {
                        Console.WriteLine(fruit + "\n");
                    }
                    Console.WriteLine("----------------------------------");
                    running = true;
                }
                else if (MenuSelector == "4")
                {
                    Console.WriteLine("Thank you for using Fruit Market. Here is what is in your cart: \n");

                    Console.WriteLine("\n----------------------------------");
                    foreach (string fruit in FruitList)
                    {
                        Console.WriteLine(fruit + "\n");
                    }
                    Console.WriteLine("----------------------------------");

                    Console.WriteLine("Have a good day!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number from the list.");
                    running = true;
                }

            }
        }
   }
}
