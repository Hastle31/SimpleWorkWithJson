using System.Threading.Tasks;
using SimpleWorkWithJson.Domain.Models;

namespace SimpleWorkWithJson.Domain.Contracts
{
    public interface IHostInfoService
    {
        Task<HostInfoAnalyzeResult> AnalyzeHostsAsync();
    }
}