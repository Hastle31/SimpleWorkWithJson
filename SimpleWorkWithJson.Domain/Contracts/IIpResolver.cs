using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Contracts
{
    /// <summary>
    /// Интерфейс получения ip адресов хоста.
    /// </summary>
    public interface IIpResolver
    {
        /// <summary>
        /// Получить ip адрес хоста.
        /// </summary>
        /// <param name="hostInfo">Хост.</param>
        /// <returns>Возвращает хост с заполненными ip адресами.</returns>
        Task<HostInfo> ResolveIpAsync(HostInfo hostInfo);
    }
}
