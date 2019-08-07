using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Models
{
    /// <summary>
    /// Информация о хосте.
    /// </summary>
    public class HostInfo
    {
        /// <summary>
        /// Урл
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Список ip адресов.
        /// </summary>
        public IEnumerable<string> Ip { get; set; }
    }
}
