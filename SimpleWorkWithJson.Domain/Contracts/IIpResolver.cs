using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Contracts
{
    public interface IIpResolver
    {
        Task<HostInfo> ResolveIpAsync(HostInfo hostInfo);
    }
}
