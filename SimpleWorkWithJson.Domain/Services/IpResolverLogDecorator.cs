using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Enums;
using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Services
{
    public class IpResolverLogDecorator : IIpResolver
    {
        private readonly IIpResolver resolver;
        private readonly ILoggerFacade logger;

        public IpResolverLogDecorator(IIpResolver resolver, ILoggerFacade logger)
        {
            this.resolver = resolver;
            this.logger = logger;
        }

        public async Task<HostInfo> ResolveIpAsync(HostInfo hostInfo)
        {
            try
            {
                return await resolver.ResolveIpAsync(hostInfo);
            }
            catch (Exception e)
            {
                logger.Log(
                    LogLevel.Error,
                    $"Can't resolve ip address from host {hostInfo.Url}",
                    e);
                throw;
            }
        }
    }
}
