using HRIS.Logger.Model.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Logger
{
    public class LoggerManager : ILoggerManager
    {
        string _logFilePath;
        public LoggerManager(string FileName, string Directory)
        {
            var logDirectory = new DirectoryInfo(Directory);

            if (!logDirectory.Exists)
            {
                logDirectory.Create();
            }

            _logFilePath = string.Concat(Directory, FileName);
        }

        public void LogInfo(string Message)
        {
            WriteLog(LogLevel.INFO, Message);
        }

        public void LogWarning(string Message)
        {
            WriteLog(LogLevel.WARN, Message);
        }

        public void LogDebug(string Message)
        {
            WriteLog(LogLevel.DEBUG, Message);
        }

        public void LogError(string Message)
        {
            WriteLog(LogLevel.ERROR, Message);
        }

        private void WriteLog(LogLevel logLevel, string LogMessage)
        {
            File.AppendAllText(_logFilePath,
                              string.Concat(Global.CurrentDateTime,
                              ConvertLogLevelToString(logLevel),
                              LogMessage,
                              Environment.NewLine));
        }

        private string ConvertLogLevelToString(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.INFO:
                    return Constant.LogLevel_Information;
                case LogLevel.WARN:
                    return Constant.LogLevel_Warning;
                case LogLevel.DEBUG:
                    return Constant.LogLevel_Debug;
                default:
                    return Constant.LogLevel_Error;
            }
        }

    }
}
