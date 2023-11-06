using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public class Fruit : IItemType
    {
        public string ItemType { get; } = "This is a fruit";
        public string Taste { get; } = "The taste is sweet";
    }
}
