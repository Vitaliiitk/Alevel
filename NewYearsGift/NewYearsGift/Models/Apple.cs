using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class Apple : Fruit, IWeight, ISubItemType, IAbstractInterface
    {
        public int Weight { get; } = 200;
        public string SubItemType { get; } = "This is an apple";
        
    }
}
