using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWorkWithJson.Domain.Models
{
    public class HostInfo
    {
        public string Url { get; set; }
        public IEnumerable<string> Ip { get; set; }
    }
}
