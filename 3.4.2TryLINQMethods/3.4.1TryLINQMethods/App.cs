
using System.Text;

namespace TryLINQMethods
{
    internal class App
    {
        public void Run()
        {
            ContactStorage contacts = new ContactStorage();

            contacts.AddContact("Vitalii Tkachenko", "+440983236115");
            contacts.AddContact("Maksym Vaihs", "+440983236415");
            contacts.AddContact("Микола Сідий", "+380983236415");
            contacts.AddContact("Щось з апострофом п'ять", "+380997236479");
            contacts.AddContact("Віталій Ткаченко", "+380983256415");
            contacts.AddContact("Vitalii Tkačenko", "+380983237415");
            contacts.AddContact("Vitalii Tkachenko", "0983236415");
            contacts.AddContact("Jozef Strečka", "+421951415327");
            contacts.AddContact("Milan Haniš", "+421953218327");
            contacts.AddContact("Džonatan Pekarčik", "+421953718327");
            contacts.AddContact("Patrik Staňa", "+421908931761");
            contacts.AddContact("петро Данилов", "0983236415");
            contacts.AddContact("Katarina", "+421994414537");
            contacts.AddContact("Dmitro Oles", "+380983236415");
            contacts.AddContact("Oleksandr Petrov", "+440983236215");
            contacts.AddContact("AnotherOne Tkačenko", "+380983236415");
            contacts.AddContact("Юрай Смілий", "+380991376415");
            contacts.AddContact("Some Name", "0993231215");
            contacts.AddContact("Dmitry Вакарчук", "0983231280");
            contacts.AddContact("Кирило Тимченко", "0993236479");

            /*contacts.PrintAllContactsAcordingToGroup("English");
            contacts.PrintAllContactsAcordingToGroup("Ukrainian");
            contacts.PrintAllContactsAcordingToGroup("#");
            contacts.PrintAllContactsAcordingToGroup("Number");*/
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Test of LINQ FirstOrDefault:");
            contacts.LINQFirstOrDefault();
            

            Console.WriteLine("\n\nTest of LINQ Where and Select:");
            contacts.LINQWhereSelect();
           

            Console.WriteLine("\nTest LINQ OrderBy:");
           /* var ukrContactsOrdered = ukrContacts.First().OrderBy(name => name.NameAndSurname);
            foreach (var cont in ukrContactsOrdered) 
            {
                Console.WriteLine($"{cont.NameAndSurname}");
            }*/
            contacts.LINQOrderBy();

            Console.WriteLine("\nTest LINQ Any:");

            contacts.AnyCyrillicName("English");

            Console.WriteLine("\nTest LINQ All:");

            contacts.AllCyrillicNames("#");

            Console.WriteLine("\nTest LINQ Reverse:");

            contacts.LINQReverse();
        }

    }
}
