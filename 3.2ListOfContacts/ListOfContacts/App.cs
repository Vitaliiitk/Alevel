using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfContacts
{
    internal class App
    {
        public void Run()
        {
            ContactStorage cont = new ContactStorage();

            cont.AddContact("Vitalii Tkachenko", "+440983236115");
            cont.AddContact("Maksym Vaihs", "+440983236415");
            cont.AddContact("Микола Сідий", "+380983236415");
            cont.AddContact("Щось з апострофом п'ять", "+380997236479");
            cont.AddContact("Віталій Ткаченко", "+380983256415");
            cont.AddContact("Vitalii Tkačenko", "+380983237415");
            cont.AddContact("Vitalii Tkachenko", "0983236415");
            cont.AddContact("Jozef Strečka", "+421951415327");
            cont.AddContact("Milan Haniš", "+421953218327");
            cont.AddContact("Džonatan Pekarčik", "+421953718327");
            cont.AddContact("Patrik Staňa", "+421908931761");
            cont.AddContact("петро Данилов", "0983236415");
            cont.AddContact("Katarina", "+421994414537");
            cont.AddContact("Dmitro Oles", "+380983236415");
            cont.AddContact("Oleksandr Petrov", "+440983236215");
            cont.AddContact("AnotherOne Tkačenko", "+380983236415");
            cont.AddContact("Юрай Смілий", "+380991376415");
            cont.AddContact("Some Name", "0993231215");
            cont.AddContact("Dmitry Вакарчук", "0983231280");
            cont.AddContact("Кирило Тимченко", "0993236479");

            cont.PrintAllContacts();

            Console.WriteLine("Check After sorting process\n");
            cont.SortAphabetic();
            cont.PrintAllContacts();
        }

    }
}
