using Hometask2._5Logger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hometask2._5Logger.Services.FileService;

namespace Hometask2._5Logger
{
    public class App
    {
        public static List<string> Run()
        {

            Actions a = new Actions();
            int rnd = 0;
            Random rand = new Random();

            for (int i = 0; i < 3; i++)
            {
                rnd = rand.Next(0, 3);
                if (rnd == 0)
                {
                    a.StartMethod();
                }
                else if (rnd == 1)
                {
                    a.BusinessException();
                }
                else
                {
                    a.ThrowsAnException();
                }
            }

            FileService fileService = new FileService();
            fileService.WriteToFfile(a.ourLog);
            ReadJsonFile readJsonFile = new ReadJsonFile();
            string logDir = readJsonFile.ReadFile();
            Console.WriteLine($"The log was written to txt file -> {logDir}");

            return a.ourLog;
        }





    }
}
