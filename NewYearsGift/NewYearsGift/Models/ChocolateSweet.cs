using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class ChocolateSweet : Sweets,  IWeight, ISubItemType, IAbstractInterface
    {
        public string features = "This contains chocolate";
        public int Weight { get; } = 20;
        public string SubItemType { get; } = "This is chocolate sweet";
    }
}
