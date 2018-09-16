using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Util
{
    public class Logger
    {
        public static int logLevel;
        public static string logPath;

        public static int DEBUG = 1;
        public static int INFO = 2;
        public static int ERROR = 3;

        private string className;
        
        public Logger(string logClass)
        {
            className = logClass;
        }

        public void debug(string text)
        {
            if (logLevel <= DEBUG)
            {
                writeLog(text, "DEBUG");
            }
        }

        public void info(string text)
        {
            if (logLevel <= INFO)
            {
                writeLog(text, "INFO");
            }
        }

        public void error(string text)
        {
            if (logLevel <= ERROR)
            {
                writeLog(text, "ERROR");
            }
        }

        private void writeLog(string text, string level)
        {
            string logFile = getLogFile();
            StringBuilder txtWriter = new StringBuilder();
            txtWriter.AppendFormat("\r\n{0} {1} {2} --> {3}", DateTime.Now.ToString("dd/MM/yyyy:HH:mm:ss:fff"), className, level, text);

            File.AppendAllText(logFile, txtWriter.ToString());
            txtWriter.Clear();
        }

        private string getLogFile()
        {
            string logFullPath = logPath + DateTime.Now.ToString("yyyyMMddHH") + ".log";
            if (!File.Exists(logFullPath))
            {
                var myFile = File.Create(logFullPath);
                myFile.Close();
            }
            return logFullPath;
        }
    }
}
