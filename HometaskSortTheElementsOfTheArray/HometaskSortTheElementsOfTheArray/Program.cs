//Our task is : An array of integers A[20] is given.
//Create another array of integers B[20], which will include all the numbers of the original array that satisfy the condition:
//A[i] <= 888, and then sort the elements of the array B[20] in descending order. To populate an array, use a pseudo-random number generator:
//new Random().Next(Min, Max);
//where Min Max are the integers of the minimum and maximum range, respectively.
namespace HometaskSortTheElementsOfTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20; // the size of our array A[20]
            int[] A = new int[a];
            int[] B = new int[a]; // another array to store values from A
            Random rand = new Random();
            Console.WriteLine("Below is our array A[20] generated via pseudorandom integers in a range from [0, 1001):\n");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(0, 1001); // this is our array built via random numbers
                Console.Write($"{A[i]} ");
            }
            Console.WriteLine("\n\nThis is our not sorted array B[20] after condition A[i] <= 888:\n");
            for (int i = 0; i < B.Length; i++)
            {
                if (A[i] <= 888)
                {
                    B[i] = A[i];
                }
                Console.Write($"{B[i]} ");
            }
            int k; // variable for storing temporary an element of array B before comparing and sorting
            for (int i = 0; i < B.Length - 1; i++)
            {
                for (int j = i + 1; j < B.Length; j++)

                    // choose and element and compare with each rest of elements
                    if (B[i] < B[j])
                    {
                        k = B[i];
                        B[i] = B[j];
                        B[j] = k;
                    }
            }
            Console.WriteLine("\n\nSorted array B[20]:\n");
            // print B[20] sorted
            foreach (int value in B)
            {
                Console.Write(value + " ");
            }

            /* //There are a lot of methods to sort Int values in arrays in ascending/descending order. Below is an example from "geeksforgeeks" forum, very interesting
             * Можливо Ви підскажете який варіант краще (цикли, чи метод "Sort", чи може ще який варінат, тому що насправді їх доволі багато)

            // declaring and initializing the array
            int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };

            // Sort array in ascending order.
            Array.Sort(arr);
            Console.WriteLine("Ascending: ");
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }

            // reverse array
            Array.Reverse(arr);
            Console.WriteLine("\n\nDescending: ");
            // print all element of array
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }*/
        }
    }
}