using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask2._5Logger.Services.Abstraction
{
    public interface ILoggerService
    {
        string Log(string logType, string massage);
    }
}
