using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Enums
{
    /// <summary>
    /// Уровни логгирования.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Отладка.
        /// </summary>
        Debug,

        /// <summary>
        /// Информация.
        /// </summary>
        Information,

        /// <summary>
        /// Предупреждение.
        /// </summary>
        Warning,

        /// <summary>
        /// Ошибка.
        /// </summary>
        Error,

        /// <summary>
        /// Критическая ошибка.
        /// </summary>
        Critical
    }
}
