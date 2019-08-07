using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Services
{
    public class IpResolver : IIpResolver
    {
        public async Task<HostInfo> ResolveIpAsync(HostInfo hostInfo)
        {
            var uri = new Uri(hostInfo.Url);
            var res = await Dns.GetHostAddressesAsync(uri.Host);
            if (res.Any())
            {
                hostInfo.Ip = res.Select(x => x.ToString());
            }

            return hostInfo;
        }
    }
}
