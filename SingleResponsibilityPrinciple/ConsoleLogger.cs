using System;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }
        // Sample call to LogMessage
        //LogMessage("WARN","Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);

        private void LogMessage(string type, string message, params object[] args)
        {
            Console.WriteLine(type + ": " + message, args);
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>" + type + "</type><message>" + message + "</message></log> ", args);
            }
        }
    }
}
