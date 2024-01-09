using System.Text.Json;


namespace LoggerWithAsynch
{
    public sealed class AppClass
    {
        public async Task Run()
        {
            Task logging1 = CallLogger1();
            Task logging2 = CallLogger1();
            await Task.WhenAll(logging1, logging2);
        }

        public async Task CallLogger1()
        {

            LoggerClass loggerClass = new LoggerClass();
            NotifyMessage notifyMessage = new NotifyMessage();
            loggerClass.NotifyLogging += notifyMessage.NotificationMessage;

            string logTxtFile = DateTime.UtcNow.ToString("MM/dd/yyyy HH'h'mm'm'ss's'") + " logFile.txt";
            string backupLogTxtFile = DateTime.UtcNow.ToString("MM/dd/yyyy HH'h'mm'm'ss's'") + " BackuplogFile.txt";
            string directory = Directory();
            string directoryToBackup = directory + "Backup\\";
            string messageToLog = "some message to log it into a file";

            int j = 0;

            loggerClass.NotifyMessage();

            for (int i = 0; i < 50; i++)
            {
                if (j < ReadJson())
                {
                    loggerClass.WriteLog(directory, logTxtFile, messageToLog + " before backup");
                }
                else
                {
                    loggerClass.WriteLog(directoryToBackup, backupLogTxtFile, messageToLog + " as a backup");
                }

                j = j + 1;
            }

            await Task.CompletedTask;
        }

        public int ReadJson()
        {
            var infoFromJson = File.ReadAllText("BackupNumber.json");
            Config configNumber = JsonSerializer.Deserialize<Config>(infoFromJson);
            return configNumber.BackUpNumber;
        }

        public string Directory()
        {
            string dbugDirectory = System.IO.Directory.GetCurrentDirectory(); // I want to go several step back from the folder Dbug
            string pathToLogToFile = Path.GetFullPath(Path.Combine(dbugDirectory, @"..\..\..\"));

            //string backUpDirectory = pathToLogToFile + $"Backup\\";
            return pathToLogToFile;
        }

    }

    public sealed class Config
    {
        public int BackUpNumber { get; set; }
    }


}
