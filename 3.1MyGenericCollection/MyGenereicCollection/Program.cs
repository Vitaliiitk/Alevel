using System;

namespace MyGenereicCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<int> intCollection = new CustomCollection<int>();

            int[] testInt = { 3, 4, 1, 5, 2 };

            int size = intCollection.Count();
            Console.WriteLine("The starting size is: " + size);
            intCollection.Add(22);
            Console.WriteLine("Check method \"Add\". We added int number \"22\": " + intCollection[0]);

            foreach (int item in testInt)
            {
                intCollection.Add(item);
            }

            Console.WriteLine("Check method \"Add\". We added 5 additional number to CustomCollection:");

            foreach (int item in intCollection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMethod \"Count\" gives the size of CustomCollection: " + intCollection.Count());
            intCollection.Sort();
            Console.WriteLine("Check result of \"Sort\" method:");

            foreach (int item in intCollection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nCheck a result of \"SetDefaultAt\" method:");
            intCollection.SetDefaultAt(0);
            intCollection.SetDefaultAt(5);

            foreach (int item in intCollection)
            {
                Console.Write(item + " ");
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  - - - - - - - - - - - - - - - - - - - - - - - - - - -

            string[] testString = { "this", "is", "just", "a", "test", "array", "filled", "with", "some", "sensless", "words" };
            CustomCollection<string> stringCollection = new CustomCollection<string>(testString);
            int sizeString = stringCollection.Count();
            Console.WriteLine("\n\nThe starting size of stringCollection is: " + sizeString);
            stringCollection.Add("random Phrase");
            Console.WriteLine("We added string \"random Phrase\": " + stringCollection[sizeString]);
            Console.WriteLine("Output all together with added phrase: ");

            foreach (string item in stringCollection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nMethod \"Count\" gives the size of CustomCollection: " + stringCollection.Count());
            stringCollection.Sort();
            Console.WriteLine("Check result of \"Sort\" method:");

            foreach (string item in stringCollection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nCheck a result of \"SetDefaultAt\" method:");
            stringCollection.SetDefaultAt(0);
            stringCollection.SetDefaultAt(5);

            foreach (string item in stringCollection)
            {
                Console.Write(item + " ");
            }
        }
    }
}