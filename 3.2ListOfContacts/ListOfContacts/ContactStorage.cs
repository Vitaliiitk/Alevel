using System.Text;
using System.Text.RegularExpressions;


namespace ListOfContacts
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
    }
}
