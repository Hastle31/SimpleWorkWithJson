using SimpleWorkWithJson.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Contracts
{
    public interface ILoggerFacade
    {
        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, string message, Exception ex);
    }
}
