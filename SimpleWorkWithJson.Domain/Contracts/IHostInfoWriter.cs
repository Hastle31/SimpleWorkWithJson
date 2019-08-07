using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Contracts
{
    public interface IHostInfoWriter
    {
        Task WriteAsync(IEnumerable<HostInfo> data);
    }
}
