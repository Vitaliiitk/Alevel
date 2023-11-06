using NewYearsGift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Services
{
    public class Search
    {
        Gift gift = new Gift();
        int lowesWeight = 0;

        public void SearchLightest()
        {

            gift.GiftBox();
            List<IAbstractInterface> myGift = gift.MyGift();
            lowesWeight = myGift[0].Weight;

            for (int i = 0; i < myGift.Count; i++)
            {
                if (myGift[i].Weight < lowesWeight)
                {
                    lowesWeight = myGift[i].Weight;

                }
            }
            Console.WriteLine($"\nLightest item in the box is {lowesWeight} gram");
        }
    }
}
