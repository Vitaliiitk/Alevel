namespace _3._3HomeWorkDelegate
{
    internal class Program
    {
        public void Show(bool resultDelegateOutput)
        {
            Console.WriteLine($"{resultDelegateOutput}");
        }

        static void Main(string[] args)
        {
            int number1 = 3;
            int number2 = 5;
            
            Program program = new Program();
            Class1 instanceClass1 = new Class1();
            Class2 instanceClass2 = new Class2();
            Class1.RefersToShow refersToShow = program.Show;
            var delegateThatShowsOurResult = instanceClass2.Calc(instanceClass1.Multiply, number1, number2);
            refersToShow(delegateThatShowsOurResult(instanceClass2.multiplyResult));
        }
    }
}