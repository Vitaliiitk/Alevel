using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPurchaseInStore.Services
{
    internal class GetClientsData
    {
        public string _firstName;
        public string _lastName;
        public string _email;
        public string WriteData() // method for GetClient method
        {
            string nameOfData;
            do
            {
                nameOfData = Console.ReadLine();
                if (string.IsNullOrEmpty(nameOfData))
                {
                    Console.WriteLine("\nYou cant leave this field empty");
                }
            }
            while (string.IsNullOrEmpty(nameOfData));
            return nameOfData;
        }

        public void GetClient() // tp get clients' data from console
        {
            Console.WriteLine("\nWrite your first name:");
            _firstName = WriteData();
            Console.WriteLine("\nWrite your last name:");
            _lastName = WriteData();
            Console.WriteLine("\nWrite your email:");
            _email = WriteData();
        }
    }
}
