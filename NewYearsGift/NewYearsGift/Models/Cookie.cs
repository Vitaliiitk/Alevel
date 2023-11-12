using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class Cookie : IItemType, IWeight, IAbstractInterface
    {
        public string ItemType { get; } = "This is not a fruit";
        public string Taste { get; } = "The taste is sweet";
        public int Weight { get; } = 80;
        public string SubItemType { get; } = "This is cookie";
    }
}
