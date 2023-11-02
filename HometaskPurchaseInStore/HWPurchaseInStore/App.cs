using HWPurchaseInStore.Models;
using HWPurchaseInStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPurchaseInStore
{
    internal class App
    {
        public void RunApp()
        {
            GoodsInStore goodsInStore = new GoodsInStore();
            SelectGoods selectGoods = new SelectGoods();
            GetClientsData getData = new GetClientsData();
            PlaceOrder placeOrder = new PlaceOrder();

            Console.WriteLine("In our store we have next goods:");

            foreach (string value in goodsInStore._fruits)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine("\n \nPlease, choose up to 10 units 1-by-1 by writing exact names of fruits then write \"finish\":\n");
            selectGoods.AddFruit();

            if (!string.IsNullOrEmpty(selectGoods._basket[0]))
            {
                getData.GetClient();
                // Console.WriteLine($"{getData._firstName}");
                Console.WriteLine("\nYou have chosen products, type \"yes\" to finish your order or \"no\" to end program");
                string command = Console.ReadLine();
                if (command != "yes" && command != "no")
                {
                    Console.WriteLine("WRITE IT CORRECTLY !!!!!!!!!!!!!!!!!!!!!!!!!!!! The program need to restart");
                }
                else if (command == "no")
                {
                    Console.WriteLine(" You canceled your order , good buy");
                }
                else if (command == "yes")
                {
                    string orderId = placeOrder.GenerateID();
                    Console.WriteLine($"\nHello, {getData._firstName} {getData._lastName}. \nThe copy of your order has been sent to your email: {getData._email} \nYou have ordered: ");
                    foreach (string item in selectGoods._basket)
                    {
                        if (!string.IsNullOrEmpty(item)) // This is because I do not want to output to the console every " " after each element of array
                        {
                            Console.Write(item + " ");
                        }

                    }
                    Console.WriteLine($"\n\nYour order identifier is: {orderId}");
                }
            }
            else
            {
                Console.WriteLine("\nYour basket is empty, you did not select anything from goods, restart the program to buy products.");
            }
        }
    }
}
