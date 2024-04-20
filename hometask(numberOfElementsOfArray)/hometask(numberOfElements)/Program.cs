//our task is : You are given an array of integers with N elements. Determine the number of elements whose values are in the range -100 to +100
namespace hometask_numberOfElements_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine($"Write an integer number to console to define a size of an array");
            string str = Console.ReadLine();// size of our future array
            bool isNumeric = int.TryParse(str, out n);// we need to exclude accidents when we miswrite or type characters instead of number

            if (string.IsNullOrEmpty(str) || !isNumeric) 
            {
                Console.WriteLine("Error: you cannot leave an array undefined or empty, you can't write a number in letters, use numeric values only");

            }
            else if (Int32.Parse(str) <= 0)
            {

                Console.WriteLine($"Error: the size of array cannot be negtive or equals to zero");
            }
            else
            {
                n = Int32.Parse(str);
                Console.WriteLine($"The size of array will be {n}");
            }

            //n = Int32.Parse(str); 
            int[] nasharray = new int[n];
            Random rand = new Random();
            Console.WriteLine("Below is our array generated via pseudorandom integers in a range from [-200, 200):");
            for (int i = 0; i < nasharray.Length; i++)
            {
                nasharray[i] = rand.Next(-200, 200); //this is our array built via random numbers
                Console.Write($"{nasharray[i]} ");
            }

            int counter = 0; //counter the number of elements whose values are in the range [-100, +100]
            int element;
            for (int i = 0; i < nasharray.Length; i++)
            {
                element = nasharray[i];
                if (element >= -100 && element <= 100)
                {
                    counter++;
                }
            }
            Console.WriteLine($"\n{counter} elements from our array are within the range [-100, 100]");
        }
    }
}