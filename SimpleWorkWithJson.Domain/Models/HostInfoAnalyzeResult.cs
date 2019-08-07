using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Models
{
    public class HostInfoAnalyzeResult
    {
        public int HostsCount { get; set; }

        public int SuccessAnalyzedHostCount { get; set; }

        public bool HostInfoSuccessSaved { get; set; }
    }
}
