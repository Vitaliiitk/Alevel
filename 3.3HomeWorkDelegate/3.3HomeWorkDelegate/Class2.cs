
namespace _3._3HomeWorkDelegate
{
    public sealed class Class2
    {
        public delegate int RefersToMultiply(int num1, int num2);
        public delegate bool RefersToResult(int num);

        public int multiplyResult { get; set; }

        public RefersToResult Calc(RefersToMultiply multiply, int number1, int number2)
        {
            
            multiplyResult = multiply(number1, number2);
            RefersToResult resultDelegate = new RefersToResult(Result);
            return resultDelegate;
        }

        public bool Result(int arg)
        {
            return arg % 2 == 0;
        }
    }
}
