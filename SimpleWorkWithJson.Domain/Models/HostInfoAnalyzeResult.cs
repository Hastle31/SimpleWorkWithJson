using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Models
{
    /// <summary>
    /// Результат анализа хостов.
    /// </summary>
    public class HostInfoAnalyzeResult
    {
        /// <summary>
        /// Всего хостов.
        /// </summary>
        public int HostsCount { get; set; }

        /// <summary>
        /// Успешно проанализированных хостов.
        /// </summary>
        public int SuccessAnalyzedHostCount { get; set; }

        /// <summary>
        /// Признак успешного сохранения результата анализа.
        /// </summary>
        public bool HostInfoSuccessSaved { get; set; }
    }
}
