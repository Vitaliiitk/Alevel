using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYearsGift.Models
{
    public interface IAbstractInterface : IItemType, ISubItemType, IWeight
    {
        public string ItemType { get; }
        public string SubItemType { get; }
        public string Taste { get; }
        public int Weight { get; }
    }
}
