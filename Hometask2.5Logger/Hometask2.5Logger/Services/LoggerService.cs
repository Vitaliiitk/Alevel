using Hometask2._5Logger.Services.Abstraction;

namespace Hometask2._5Logger.Services
{
    public class LoggerService : ILoggerService
    {

        public string Log(string logType, string massage)
        {
            var log = $"{DateTime.UtcNow} {logType} {massage}";

            return log;
        }
    }
}
