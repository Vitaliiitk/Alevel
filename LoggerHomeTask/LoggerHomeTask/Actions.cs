using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LoggerHomeTask
{
    public class Actions
    {

        public Result Method1()
        {
            string nameMessage = "Start method";
            string type = "Info";
            Result obj1 = new Result(type);
            Logger.WriteLog(type, nameMessage);
            return obj1;
        }
        public Result Method2()
        {
            string nameMessage = "Skipped logic in method";
            string type = "Warning";
            Result obj2 = new Result(type);
            Logger.WriteLog(type, nameMessage);
            return obj2;
        }

        public Result Method3()
        {
            string type = "Error";
            Result obj3 = new Result(type);
            string nameMessage = "Action failed by a reason: " + obj3.ErrorMessage;

            Logger.WriteLog(type, nameMessage);
            return obj3;
        }

    }
    public class Result
    {
        public string Type { get; set; }
        public bool Status { get; }
        public string ErrorMessage { get; }

        public Result(string type)
        {
            Type = type;

            if (type == "Info" || type == "Warning")
            {
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
