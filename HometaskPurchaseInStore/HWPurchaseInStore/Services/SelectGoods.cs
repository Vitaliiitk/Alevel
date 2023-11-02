using HWPurchaseInStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HWPurchaseInStore.Services
{
    public class SelectGoods
    {
        public string[] _basket = new string[10];
        int _numberFruits = 0;
        //public string[] cart = new string[numberFruits];
        GoodsInStore frt = new GoodsInStore(); // Create instance from class Goods

        public void AddFruit()
        {
            for (int i = 0; i < _basket.Length; i++)
            {
                string fruit = Console.ReadLine();
                if (!frt._fruits.Contains(fruit) && fruit != "finish")
                {
                    i--;
                    Console.WriteLine("The type of fruit is absent in our store, please, make sure you write the name of order correctly and try again or type" +
                        " word \"finish\" to stop choosing");
                }
                else if (frt._fruits.Contains(fruit))
                {
                    _numberFruits++;
                    _basket[i] = fruit;

                }
                else if (fruit == "finish")
                {
                    break;
                }
            }
            if (_numberFruits == 10)
            {
                Console.WriteLine("You can choose maximum 10 products !");
            }
        }
    }
}
