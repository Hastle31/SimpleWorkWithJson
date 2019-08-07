using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Enums;
using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Services
{
    public class HostInfoService : IHostInfoService
    {
        private readonly IHostInfoReader reader;
        private readonly IHostInfoWriter writer;
        private readonly IIpResolver resolver;
        private readonly ILoggerFacade loggerFacade;

        public HostInfoService(
            IHostInfoReader reader,
            IHostInfoWriter writer,
            IIpResolver resolver,
            ILoggerFacade loggerFacade)
        {
            this.reader = reader;
            this.writer = writer;
            this.resolver = resolver;
            this.loggerFacade = loggerFacade;
        }

        public async Task<HostInfoAnalyzeResult> AnalyzeHostsAsync()
        {
            HostInfoAnalyzeResult result = new HostInfoAnalyzeResult();
            try
            {
                var hostInfos = await reader.ReadAsync();
                result.HostsCount = hostInfos.Count;

                Task<HostInfo[]> aggregateTask = null;
                try
                {
                    var tasks = hostInfos.Select(hi => resolver.ResolveIpAsync(hi)).ToArray();
                    aggregateTask = Task.WhenAll(tasks);
                    await aggregateTask;
                    result.SuccessAnalyzedHostCount = tasks.Length;
                }
                catch (Exception)
                {
                    result.SuccessAnalyzedHostCount = result.HostsCount - aggregateTask.Exception.InnerExceptions.Count;
                    loggerFacade.Log(LogLevel.Error, "Resolving ip address problem.", aggregateTask.Exception);
                }

                await writer.WriteAsync(hostInfos);
                result.HostInfoSuccessSaved = true;
            }
            catch (Exception e)
            {
                loggerFacade.Log(LogLevel.Error, "Can't analyze hosts", e);
            }

            return result;
        }
    }
}
