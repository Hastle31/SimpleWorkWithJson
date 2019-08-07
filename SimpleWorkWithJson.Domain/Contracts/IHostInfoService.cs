using System.Threading.Tasks;
using SimpleWorkWithJson.Domain.Models;

namespace SimpleWorkWithJson.Domain.Contracts
{
    /// <summary>
    /// Интерфейс серсиса анализа хостов.
    /// </summary>
    public interface IHostInfoService
    {
        /// <summary>
        /// Проанализировать хосты.
        /// </summary>
        /// <returns>Возвращает результат анализа.</returns>
        Task<HostInfoAnalyzeResult> AnalyzeHostsAsync();
    }
}