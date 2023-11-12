using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class Lollipop : Sweets, IWeight, ISubItemType, IAbstractInterface
    {
        public string features = "This is pure sugar";
        public int Weight { get; } = 10;
        public string SubItemType { get; } = "This is lollipop";
    }
}
