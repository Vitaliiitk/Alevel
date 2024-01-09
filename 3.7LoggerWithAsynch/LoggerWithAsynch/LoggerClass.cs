
namespace LoggerWithAsynch
{
    public delegate void Notify();

    public sealed class LoggerClass
    {
        public event Notify NotifyLogging;

        public async Task WriteLog(string dir, string file, string message)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file), true))
            {
                await outputFile.WriteLineAsync($"{DateTime.UtcNow} {message}");
            }
        }

        public void NotifyMessage()
        {
            if (NotifyLogging != null)
            {
                NotifyLogging();
            }
        }
    }

    public sealed class NotifyMessage
    {
        public void NotificationMessage()
        {
            Console.WriteLine("Logging process started");
        }
    }
}

