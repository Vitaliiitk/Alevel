namespace CreateAsynchronousMethod
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            ReadFromFile concat = new ReadFromFile();
            string resultedString = concat.ConcatetionOfText().Result;
            Console.WriteLine(resultedString);
            
        }
    }
}