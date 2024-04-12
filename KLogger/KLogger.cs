using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KLoggerTool
{
    public class KLogger
    {
        public static void Main()
        {
            File.WriteAllText("KLogger.log", $"------New Log File Created at {DateTime.Now}------\n");
        }

        public static void ClearLog()
        {
            File.WriteAllText("KLogger.log", $"------New Log File Created at {DateTime.Now}------\n");
        }


        /// <summary>
        /// Creates new log entry with a "[INFO]" tag.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerFile"></param>
        /// <param name="caller"></param>
        /// <param name="lineNumber"></param>
        public static void Info(string message, [CallerFilePath] string callerFile = null, [CallerMemberName] string caller = null, [CallerLineNumber] int lineNumber = 0)
        {
            string level = "[INFO]";
            string fileName = callerFile.Split('\\').Last();
            DebugSend(level, fileName, caller, lineNumber, message);
        }
        /// <summary>
        /// Creates new log entry with a "[WARN]" tag.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerFile"></param>
        /// <param name="caller"></param>
        /// <param name="lineNumber"></param>
        public static void Warn(string message, [CallerFilePath] string callerFile = null, [CallerMemberName] string caller = null, [CallerLineNumber] int lineNumber = 0)
        {
            string level = "[WARN]";
            string fileName = callerFile.Split('\\').Last();
            DebugSend(level, fileName, caller, lineNumber, message);
        }
        /// <summary>
        /// Creates new log entry with a "[ERROR]" tag.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerFile"></param>
        /// <param name="caller"></param>
        /// <param name="lineNumber"></param>
        public static void Error(string message, [CallerFilePath] string callerFile = null, [CallerMemberName] string caller = null, [CallerLineNumber] int lineNumber = 0)
        {
            string level = "[ERROR]";
            string fileName = callerFile.Split('\\').Last();
            DebugSend(level, fileName, caller, lineNumber, message);
        }





        /// <summary>
        /// Send Raw Message Directly to log file. Not recommended. This does not track method, line number, or file of origin.
        /// </summary>
        /// <param name="message"></param>
        private static void DebugSend(string message)
        {
            message = message.ToString();
            File.AppendAllText("KLogger.log", $" {DateTime.Now} {DateTime.Now.ToString("HH:mm:ss.fff")} --- [] | {message}\n");
        }
        private static void DebugSend(string procId, string message)
        {
            message = message.ToString();
            File.AppendAllText("KLogger.log", $" {DateTime.Now} {DateTime.Now.ToString("HH:mm:ss.fff")} --- {procId} | {message}\n");
        }
        private static void DebugSend(string level, string procId, string message)
        {
            message = message.ToString();
            File.AppendAllText("KLogger.log", $" {DateTime.Now} {DateTime.Now.ToString("HH:mm:ss.fff")} --- {level} {procId} | {message}\n");
        }
        private static void DebugSend(string level, string fileName, string caller, int lineNumber, string message)
        {
            message = message.ToString();
            File.AppendAllText("KLogger.log", $" {DateTime.Now.ToString("MM/dd/yyyy")} {DateTime.Now.ToString("HH:mm:ss.fff")} --- {level} {fileName} [{caller}] [{lineNumber}] | {message}\n");
        }
    }


}
