/* Our task is:
Use StyleCope in a project.
Create and array with N elements, where N is specified from the console line.
Fill it with random numbers from 1 to 26 inclusive.
Create 2 arrays, where in first array there will be only even values, and in the second - odd.
Replace numbers in array 1 and 2 with letters of English alphabet.
The cell values of these arrays are equal to the ordinal numbers of each letter in the alphabet.
If the letter is one of the list (a, e, i, d, h, j) then it must be in uppercase.
Display the result of which array contains more uppercase letters. Print both arrays to the screen.
Each of the arrays should be displayed in 1 line, where its values will be separated.
*/
namespace PartOfModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // size of our future array
            int n = 0;
            Console.WriteLine($"Write an integer number to console to define a size of an array");
            string str = Console.ReadLine();

            // we need to exclude accidents when we miswrite or type characters instead of number
            bool isNumeric = int.TryParse(str, out n);

            if (string.IsNullOrEmpty(str) || !isNumeric)
            {
                Console.WriteLine("Error: you cannot leave an array undefined or empty, you can't write a number in letters, use numeric values only");
            }
            else if (Int32.Parse(str) <= 0)
            {
                Console.WriteLine($"\nError: the size of array cannot be negtive or equals to zero");
            }
            else
            {
                n = Int32.Parse(str);
                Console.WriteLine($"\nThe size of the original array will be {n}");
            }

            int[] nashArray = new int[n];
            int oddNumbers = 0;
            int evenNumbers = 0;
            Random rand = new Random();
            Console.WriteLine("\nBelow is our array generated via pseudorandom integers in a range from [1, 26]:");
            for (int i = 0; i < nashArray.Length; i++)
            {
                nashArray[i] = rand.Next(1, 27);
                if (nashArray[i] % 2 == 0)
                {
                    evenNumbers++;
                }
                else
                {
                    oddNumbers++;
                }

                Console.Write($"{nashArray[i]} ");
            }

            int[] evenArray = new int[evenNumbers];
            int[] oddArray = new int[oddNumbers];

            // I need counters j, k for regrouping odd and even numbers from original array "nashArray".
            int j = 0;
            int k = 0;
            foreach (int value in nashArray)
            {
                if (value % 2 == 0)
                {
                    evenArray[j] = value;
                    j++;
                }
                else
                {
                    oddArray[k] = value;
                    k++;
                }
            }

            // Create a new "actions" for "int" and "char" to show 1 by 1 elemen of even and odd arrays. Each array on the new line
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.foreach?view=net-7.0
            Action<int> action1 = new Action<int>(ShowElements);
            static void ShowElements(int val)
        {
            Console.Write($"{val} ");
        }

            Action<char> action2 = new Action<char>(ShowLetters);
            static void ShowLetters(char ch)
            {
                Console.Write($"{ch} ");
            }

            Console.WriteLine($"\n\n{evenNumbers} evenNumbers:");
            Array.ForEach(evenArray, action1);
            Console.WriteLine($"\n\n{oddNumbers} oddNumbers:");
            Array.ForEach(oddArray, action1);
            Console.WriteLine("\n");
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            // To store chars, letters
            char[] evenAlphabet = new char[evenNumbers];
            char[] oddAlphabet = new char[oddNumbers];

            // counters for foreach
            int evenCounterOfBigLetters = 0;
            int oddCounterOfBigLetters = 0;
            int e = 0;
            int o = 0;

            // We need to keep in mind exception (a - 1, e - 5, i - 9, d - 4, h - 8, j - 10), these letters should be uppercase.
            foreach (int evenValue in evenArray)
            {
                if (evenValue == 4 || evenValue == 8 || evenValue == 10)
                {
                    evenAlphabet[e] = Char.ToUpper(alphabet[evenValue - 1]);
                    e++;
                    evenCounterOfBigLetters++;
                }
                else
                {
                    evenAlphabet[e] = alphabet[evenValue - 1];
                    e++;
                }
            }

            foreach (int oddValue in oddArray)
            {
                if (oddValue == 1 || oddValue == 5 || oddValue == 9)
                {
                    oddAlphabet[o] = Char.ToUpper(alphabet[oddValue - 1]);
                    o++;
                    oddCounterOfBigLetters++;
                }
                else
                {
                    oddAlphabet[o] = alphabet[oddValue - 1];
                    o++;
                }
            }

            if (evenCounterOfBigLetters > oddCounterOfBigLetters)
            {
                Console.WriteLine($"Array of even numbers contains more uppercase letters and the number of uppercase letters is {evenCounterOfBigLetters}.");
            }
            else if (evenCounterOfBigLetters < oddCounterOfBigLetters)
            {
                Console.WriteLine($"Array of odd numbers contains more uppercase letters and the number of uppercase letters is {oddCounterOfBigLetters}.");
            }
            else
            {
                Console.WriteLine($"None of the arrays contain majority of uppercase letters, number is equal and the number of uppercase letters is {evenCounterOfBigLetters}.");
            }

            Console.WriteLine($"\n{evenNumbers} evenNumbers [{string.Join(", ", evenArray)}] correspond to array of letters:");
            Array.ForEach(evenAlphabet, action2);
            Console.WriteLine($"\n\n{oddNumbers} oddNumbers [{string.Join(", ", oddArray)}] correspond to array of letters:");
            Array.ForEach(oddAlphabet, action2);
        }
    }
}