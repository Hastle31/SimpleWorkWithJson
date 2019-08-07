using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Common.Logging
{
    public class ConsoleLogger : ILoggerFacade
    {
        public void Log(LogLevel logLevel, string message)
        {
            Log(logLevel, message, null);
        }

        public void Log(LogLevel logLevel, string message, Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[{logLevel.ToString()}] {message}");

            if (ex != null)
            {
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
