using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Enums;
using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.Domain.Services
{
    public class HostInfoServiceLogDecorator : IHostInfoService
    {
        private readonly IHostInfoService hostInfoService;
        private readonly ILoggerFacade logger;

        public HostInfoServiceLogDecorator(IHostInfoService hostInfoService, ILoggerFacade logger)
        {
            this.hostInfoService = hostInfoService;
            this.logger = logger;
        }

        public async Task<HostInfoAnalyzeResult> AnalyzeHostsAsync()
        {
            logger.Log(LogLevel.Debug, "Started analyze hosts");

            var res = await hostInfoService.AnalyzeHostsAsync();

            var sb = new StringBuilder();
            sb.AppendLine("Finished analyze hosts");
            sb.AppendLine($"{res.HostsCount} hosts was analyzed.");
            sb.AppendLine($"{res.SuccessAnalyzedHostCount} of them are successful analyzed.");
            sb.AppendLine(string.Format("Results {0} saved", res.HostInfoSuccessSaved ? "successfully" : "are not"));
            logger.Log(LogLevel.Debug, sb.ToString());

            return res;
        }
    }
}
