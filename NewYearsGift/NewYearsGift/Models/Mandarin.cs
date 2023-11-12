using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class Mandarin : Fruit, ISubItemType, IWeight, IAbstractInterface
    { 
        public int Weight { get; } = 70;
        public string SubItemType { get; } = "This is mandarin";
    }
}
