namespace IncorrectConvection
{
    using System;
    using System.Collections.Generic;

    public class MyClass //myclass is incorrect format
    {
        public int myVar;

        public void CalculateTotal() // calculate_total incorrect format
        {
            int value1 = 5; // відступи
            int value2 = 10; // відступи

            int result = value1 + value2; //відступи

            Console.WriteLine("The result is: " + result); //відступ перед +
        }
    }

    namespace AnotherNamespace
    {
        public class AnotherClass
        {
            public void AnotherMethod()
            {
                if (true) // дужки
                {
                    // Порушено правило щодо розташування фігурних дужок
                    // Код
                }

                int myVariable = 5; //format
            }
        }
    }

    public class Program
    {
        public static void Main() // not main
        {
            int a = 10; //відступи
            int b = 20; // відступи
            int result = a + b; //відступи
            Console.WriteLine("The result is: " + result); // відступи
        }

        /*public static void Main() //2 рази метод main?
        {
            // Код
        }*/
    }
}