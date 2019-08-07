using SimpleWorkWithJson.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Contracts
{
    /// <summary>
    /// Интерфейс логгера.
    /// </summary>
    public interface ILoggerFacade
    {
        /// <summary>
        /// Залоггировать.
        /// </summary>
        /// <param name="logLevel">Уровень логгирования.</param>
        /// <param name="message">Сообщение.</param>
        void Log(LogLevel logLevel, string message);

        /// <summary>
        /// Залоггировать.
        /// </summary>
        /// <param name="logLevel">Уровень логгирования.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="ex">Исключение</param>
        void Log(LogLevel logLevel, string message, Exception ex);
    }
}
