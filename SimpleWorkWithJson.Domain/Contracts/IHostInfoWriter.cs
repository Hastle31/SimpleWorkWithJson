using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Contracts
{
    /// <summary>
    /// Интерфейс записи информации о хостах.
    /// </summary>
    public interface IHostInfoWriter
    {
        /// <summary>
        /// Записать информацию о хостах.
        /// </summary>
        /// <param name="data">Список хостов.</param>
        Task WriteAsync(IEnumerable<HostInfo> data);
    }
}
