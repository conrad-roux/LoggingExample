using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Logging.Logic
{
    public class Log : ILogger
    {
        static string logPath = @"C:\Temp\Log\";

        private void Text(string toWrite, string filePathName)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filePathName, true))
            {
                file.WriteLine($"{DateTime.Now.ToString()}\t{toWrite}");
            }
        }

        private void Text(string toWrite)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(string.Concat(logPath, $"{DateTime.Now.Date.ToString(@"yyyy-MM-dd")}system.log"), true))
            {
                file.WriteLine($"{DateTime.Now.ToString()}\t{toWrite}");
            }
        }

        public void Write(string toWrite, LogType logType, string filePathName)
        {
            switch (logType)
            {
                case LogType.TextFile:
                    Text(toWrite, filePathName);
                    break;
                case LogType.Trace:
                    Debug(toWrite);
                    break;
            }
        }

        public void Write(string toWrite, LogType logType)
        {
            switch (logType)
            {
                case LogType.TextFile:
                    Text(toWrite);
                    break;
                case LogType.Trace:
                    Debug(toWrite);
                    break;
            }
        }

        public void Debug(string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        private void Source(string source)
        {

        }

        public void Write(string text)
        {
            throw new NotImplementedException();
        }
    }
}
