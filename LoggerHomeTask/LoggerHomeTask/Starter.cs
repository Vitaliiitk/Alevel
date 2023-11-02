using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerHomeTask
{
    internal class Starter
    {
        public static void Run()
        {
            // тут цикл на 100 ітерацій викликає один із трьох методів випадковим чином
            Actions a = new Actions();
            int rnd = 0;
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                rnd = rand.Next(0, 3);
                if (rnd == 0)
                {
                    a.Method1();
                }
                else if (rnd == 1)
                {
                    a.Method2();
                }
                else
                {
                    a.Method3();
                }
            }


        }
    }
}
