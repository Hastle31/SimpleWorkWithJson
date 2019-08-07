using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Contracts
{
    /// <summary>
    /// Интерфейс чтения хостов.
    /// </summary>
    public interface IHostInfoReader
    {
        /// <summary>
        /// Получить хосты.
        /// </summary>
        /// <returns>Возвращает список хостов.</returns>
        Task<List<HostInfo>> ReadAsync();
    }
}
