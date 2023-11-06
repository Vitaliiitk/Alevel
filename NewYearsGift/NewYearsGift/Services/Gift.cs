using NewYearsGift.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Services
{
    public class Gift
    {

        List<IAbstractInterface> myGift = new List<IAbstractInterface>();
        public int boxWeight = 0;

        public void GiftBox()
        {
            Apple apple = new Apple();
            Mandarin mandarin = new Mandarin();
            Cookie cookie = new Cookie();
            ChocolateSweet chocolateSweet = new ChocolateSweet();
            Lollipop lollipop = new Lollipop();
            myGift.Add(apple);
            myGift.Add(lollipop);
            myGift.Add(mandarin);
            myGift.Add(chocolateSweet);
            myGift.Add(cookie);
            
            foreach (IAbstractInterface obj in myGift)
            {
                boxWeight = boxWeight + obj.Weight;
            }
        }
        public void GiftContains() 
        {
            foreach (IAbstractInterface obj in myGift)
            {
                Console.Write($"{obj.SubItemType}  ");
            }
        }
        public List<IAbstractInterface> MyGift()
        {
            return myGift;
        }
    }
}
