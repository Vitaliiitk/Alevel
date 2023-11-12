using NewYearsGift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Services
{
    internal class Sort
    {
        Gift gift = new Gift();

        public void SortBox()
        {
            gift.GiftBox();
            List<IAbstractInterface> myGift = gift.MyGift();
            Console.WriteLine("Sort from lightest to heviest:");
            var enum1 = from gift in myGift orderby gift.Weight select gift;
            foreach (var e in enum1)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*Вище взято з цього прикладу:
         * 
         * var users = new List<User> {
        new ("John", "Doe", 1230),
        new ("Lucy", "Novak", 670),
        new ("Ben", "Walter", 2050),
        new ("Robin", "Brown", 2300),
        new ("Joe", "Draker", 1190),
        new ("Janet", "Doe", 980),
        };
        Console.WriteLine("sort ascending by salary");

        var enum1 = from user in users
        orderby user.Salary
        select user;

        foreach (var e in enum1)
        {
        Console.WriteLine(e);
        }*/
    }


}
