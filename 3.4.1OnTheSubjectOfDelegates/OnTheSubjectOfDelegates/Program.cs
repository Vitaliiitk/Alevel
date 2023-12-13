namespace OnTheSubjectOfDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorClass calcInstance = new CalculatorClass();
            calcInstance.WrapperMethod(10, 15);
        }
    }
}