using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ListOfContacts
{
    public sealed class ContactStorage
    {

        private readonly List<string> keys = new List<string>()
        {
            "English",
            "Ukrainian",
            "#",
            "Number"
        };

        private Dictionary<string, List<Contact>> phoneBook = new Dictionary<string, List<Contact>>();
        public ContactStorage()
        {
            phoneBook.Add(keys[0], new List<Contact>());
            phoneBook.Add(keys[1], new List<Contact>());
            phoneBook.Add(keys[2], new List<Contact>());
            phoneBook.Add(keys[3], new List<Contact>());
        }

        public void AddContact(string nameAndSurname, string phoneNumber)
        {
            Contact contact = new Contact()
            {
                NameAndSurname = nameAndSurname,
                PhoneNumber = phoneNumber
            };

            try
            {
                if (IsEnglish(nameAndSurname) == true && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+44"))
                {
                    phoneBook[keys[0]].Add(contact);
                }

                else if (IsUkrainian(nameAndSurname) == true && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+38"))
                {
                    phoneBook[keys[1]].Add(contact);
                }

                else if (IsEnglish(nameAndSurname) == false && IsUkrainian(nameAndSurname) == false && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+"))
                {
                    phoneBook[keys[2]].Add(contact);
                }

                else if (Regex.IsMatch(phoneNumber, @"^\d{10}"))
                {
                    phoneBook[keys[3]].Add(contact);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public static bool IsEnglish(string input)
        {

            // Define a regular expression pattern to match English letters, numbers, and spaces
            string pattern = @"^[A-Za-z0-9\s]+$";

            return Regex.IsMatch(input, pattern);
        }

        public static bool IsUkrainian(string input)
        {
            // Ukrainian alphabet ranges in Unicode
            string ukrainianPattern = @"^[ІЇҐА-ЩЬЄЮЯіїґа-щьєюя0-9\'\s]+$";
            return Regex.IsMatch(input, ukrainianPattern);
        }

        public void SortAphabetic()
        {
            for (int i = 0; i < 4; i++)
            {
                phoneBook[keys[i]] = phoneBook[keys[i]].OrderBy(x => x.NameAndSurname).ToList();
                //phoneBook[keys[i]].Sort((x, y) => string.Compare(x.NameAndSurname, y.NameAndSurname)); // Який варіант краще розглядати? Цей чи верхній?
            }
        }

        public void PrintAllContacts()
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{keys[i]}: ");
                foreach (var item in phoneBook[keys[i]])
                {
                    Console.Write(item.NameAndSurname + "-->" + item.PhoneNumber + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
