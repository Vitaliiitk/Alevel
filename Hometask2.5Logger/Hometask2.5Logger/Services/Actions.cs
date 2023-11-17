using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask2._5Logger.Services
{
    public class Actions
    {
        public List<string> ourLog = new List<string>();
        LoggerService logger = new LoggerService();

        public Result StartMethod()
        {
            string nameMessage = "Start method";
            string type = "Info";
            Result obj1 = new Result(type);
            ourLog.Add(logger.Log(type, nameMessage));
            return obj1;
        }
        public Result BusinessException()
        {
            string type = "Warning";
            Result obj2 = new Result(type);
            string nameMessage = "BusinessException. Action got this custom Exception : " + obj2.WarningMessage;
            ourLog.Add(logger.Log(type, nameMessage));
            return obj2;
        }

        public Result ThrowsAnException()
        {
            string type = "Error";
            Result obj3 = new Result(type);
            string nameMessage = "ThrowsAnException. Action failed by a reason: " + obj3.ErrorMessage;
            ourLog.Add(logger.Log(type, nameMessage));
            return obj3;
        }

    }
    public class Result
    {
        public string Type { get; set; }
        public bool Status { get; }
        public string ErrorMessage { get; }
        public string WarningMessage { get; }

        public Result(string type)
        {
            Type = type;

            if (type == "Info")
            {
                Status = true;
            }
            else if (type == "Warning")
            {
                WarningMessage = "Skipped logic in method";
                Status = true;
            }
            else if (type == "Error")
            {
                ErrorMessage = "I broke a logic";
                Status = false;
            }
        }
    }
}
