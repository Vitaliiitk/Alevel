using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerHomeTask
{
    public static class Logger
    {
        // Це взято з відео від Петра про логгер
        public static void WriteLog(string logtype, string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {logtype} : {message}");
            }
        }
    }
}
