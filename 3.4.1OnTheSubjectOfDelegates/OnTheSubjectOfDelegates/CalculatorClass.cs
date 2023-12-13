using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheSubjectOfDelegates
{
    public delegate int CalculateEventHandler(int a, int b);

    public sealed class CalculatorClass
    {
        public event CalculateEventHandler OnCalculate;

        public int Calculate(int a, int b)
        {
            int result;
            return result = a + b;
        }

        public void WrapperMethod(int x, int y)
        {
            if (OnCalculate != null)
            {
                OnCalculate(x, y);
            }

            try
            {
                OnCalculate += Calculate;
                OnCalculate += Calculate;
                var functionsCalculate = OnCalculate.GetInvocationList();

                int result = 0;

                foreach (Delegate calculateFunction in functionsCalculate)
                {
                    result = result + (int)calculateFunction.DynamicInvoke(x, y);
                }

                Console.WriteLine($"{result}");
            }
            catch (Exception except)
            {
                Console.WriteLine(except);
            }
        }
    }
}
