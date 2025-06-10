using System;
using System.IO;

namespace SingletonPattern
{
    public class Logger
    {
        private readonly string path = "log.txt";

        public void LogInformation(string message)
        {
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{DateTime.Now} {message}");
        }

        private Logger()
        {
            
        }

        private static object _syncLock = new object();

        private static Logger _instance;

        public static Logger Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
            }
        }
    }
}
