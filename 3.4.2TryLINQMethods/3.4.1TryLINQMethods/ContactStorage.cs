using System.Text;
using System.Text.RegularExpressions;


namespace TryLINQMethods
{
    public sealed class ContactStorage
    {
        private const string english = "English";
        private const string ukrainian = "Ukrainian";
        private const string signSharp = "#";
        private const string number = "Number";

        private Dictionary<string, List<Contact>> phoneBook = new Dictionary<string, List<Contact>>();
        public ContactStorage()
        {
            phoneBook.Add(english, new List<Contact>());
            phoneBook.Add(ukrainian, new List<Contact>());
            phoneBook.Add(signSharp, new List<Contact>());
            phoneBook.Add(number, new List<Contact>());
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
                if (IsEnglish(nameAndSurname) && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+44"))
                {
                    phoneBook[english].Add(contact);
                }

                else if (IsUkrainian(nameAndSurname) && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+38"))
                {
                    phoneBook[ukrainian].Add(contact);
                }

                else if (!IsEnglish(nameAndSurname) && !IsUkrainian(nameAndSurname) && Regex.IsMatch(phoneNumber, @"^\u002b\d{12}") && phoneNumber.StartsWith("+"))
                {
                    phoneBook[signSharp].Add(contact);
                }

                else if (Regex.IsMatch(phoneNumber, @"^\d{10}"))
                {
                    phoneBook[number].Add(contact);
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

        public void PrintAllContactsAcordingToGroup(string englishOrUkrainianOrSignSharpOrNumber)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                phoneBook[englishOrUkrainianOrSignSharpOrNumber] = phoneBook[englishOrUkrainianOrSignSharpOrNumber].OrderBy(x => x.NameAndSurname).ToList();

                Console.WriteLine($"{englishOrUkrainianOrSignSharpOrNumber}: ");
                foreach (var item in phoneBook[englishOrUkrainianOrSignSharpOrNumber])
                {
                    Console.Write(item.NameAndSurname + "-->" + item.PhoneNumber + " ");
                }
                Console.WriteLine("\n");
            }

            catch (Exception couldBeWrongDictionaryKey)
            {
                Console.WriteLine($"Error: {couldBeWrongDictionaryKey.Message}");
            }
        }

        public void LINQFirstOrDefault()
        {
            var someContacts = phoneBook.FirstOrDefault(contact => contact.Key == "#");
            var someContacts2 = phoneBook.FirstOrDefault(contact => contact.Key == "randomKey");

            Console.WriteLine("Non existing key \"randomKey\" returns NULL KayValuePair as default, while \"#\" returns list of contacts with which we can further interact," +
                "for example, output:");

            foreach (var item in someContacts.Value)
            {
                Console.Write($"{item.NameAndSurname} -> {item.PhoneNumber} |");
            }
        }

        public void LINQWhereSelect()
        {
            var ukrContacts = phoneBook
                                .Where(contactList => contactList.Key.Contains("Ukrainian"))
                                .Select(contactList => contactList.Value);


            foreach (var item in ukrContacts.First())
            {
                Console.WriteLine($"{item.NameAndSurname} number is {item.PhoneNumber}| ");
            }
        }

        public void LINQOrderBy()
        {
            var ukrContactsOrdered = phoneBook["Ukrainian"].OrderBy(name => name.NameAndSurname);
            foreach (var cont in ukrContactsOrdered)
            {
                Console.WriteLine($"{cont.NameAndSurname}");
            }
        }

        public void AnyCyrillicName(string dictionaryKey)
        {
            var anyCyrillicName = phoneBook[dictionaryKey];
            string ukrainianPattern = @"^[ІЇҐА-ЩЬЄЮЯіїґа-щьєюя0-9\'\s]+$";
            bool anyCyrillic = anyCyrillicName.Any(name => Regex.IsMatch(name.NameAndSurname, ukrainianPattern));

            Console.WriteLine($"{anyCyrillic}");
        }

        public void AllCyrillicNames(string dictionaryKey)
        {
            var allCyrillicNames = phoneBook[dictionaryKey];
            string ukrainianPattern = @"^[ІЇҐА-ЩЬЄЮЯіїґа-щьєюя0-9\'\s]+$";
            bool allCyrillic = allCyrillicNames.All(name => Regex.IsMatch(name.NameAndSurname, ukrainianPattern));

            Console.WriteLine($"{allCyrillic}");
        }

        public void LINQReverse()
        {
            var reversePhonebook = phoneBook.AsEnumerable().Reverse();
            foreach (var pair in reversePhonebook)
            {
                Console.WriteLine($"{pair.Key} and here some list of contacts, like {{pair.Value}}");
            }
        }
    }
}
