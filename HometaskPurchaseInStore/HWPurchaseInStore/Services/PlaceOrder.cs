using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPurchaseInStore.Services
{
    internal class PlaceOrder
    {
        public string GenerateID()
        {
            string id;
            id = Guid.NewGuid().ToString();
            return id;
        }
    }
}
