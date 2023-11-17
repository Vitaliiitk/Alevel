using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hometask2._5Logger.Services
{
    public class FileService
    {
        public void WriteToFfile(List<string> info)
        {
            ReadJsonFile readJsonFile = new ReadJsonFile();
            string logDir = readJsonFile.ReadFile();

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            string fullTxtName = DateTime.UtcNow.ToString("MM/dd/yyyy HH'h'mm'm'ss's'") + " logFile.txt";


            // This variant doesnt work because it deletes not the lastWriteTime txt file:

            /* string[] txtFilesInOurFolder = Directory.GetFiles(logDir);
            int numberOfFiles = txtFilesInOurFolder.Length;
            foreach (var item in txtFilesInOurFolder)
            {
                Console.WriteLine(item);
            }
            int i = 0;
            if (numberOfFiles >= 3)
            {
                do
                {
                    File.Delete(txtFilesInOurFolder[i]);
                    i++;
                    numberOfFiles--;
                } while (numberOfFiles > 2);
            }*/

            try
            {
                using (StreamWriter writer = new StreamWriter(logDir + fullTxtName))
                {
                    List<string> infoToLog = info;
                    foreach (string item in infoToLog)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try // Delete last created file or if there are many files (more than 3) delete all but leave last 3 files.
            {
                foreach (var txtFile in new DirectoryInfo(logDir).GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(3))
                    txtFile.Delete();
            }
            catch (Exception absentDirectory)
            {
                Console.WriteLine(absentDirectory);
                Console.WriteLine("There is no such a directory");
            }
        }

        public class ReadJsonFile
        {
            public string ReadFile()
            {

                string dbugDir = System.IO.Directory.GetCurrentDirectory(); // I want to go several step back from the folder Dbug
                string jsonDir = Path.GetFullPath(Path.Combine(dbugDir, @"..\..\..\"));

                var builder = new ConfigurationBuilder()
                                    .SetBasePath(jsonDir)
                                    .AddJsonFile("jsconfig.json", optional: true, reloadOnChange: true);

                string logFilePath = builder.Build().GetSection("Logger").GetSection("Path").Value;

                return logFilePath;
            }
        }
    }
}

