using Newtonsoft.Json;
using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWorkWithJson.DataAccess
{
    public class HostInfoJsonWriter : IHostInfoWriter
    {
        private readonly string filepath;

        public HostInfoJsonWriter(string filepath)
        {
            this.filepath = filepath;
        }

        public async Task WriteAsync(IEnumerable<HostInfo> data)
        {
            using (var writer = new StreamWriter(filepath))
            {
                var json = JsonConvert.SerializeObject(data);
                await writer.WriteAsync(json);
            }
        }
    }
}
