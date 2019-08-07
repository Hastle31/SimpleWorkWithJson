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
    public class HostInfoJsonReader : IHostInfoReader
    {
        private readonly string filepath;

        public HostInfoJsonReader(string filepath)
        {
            this.filepath = filepath;
        }

        public async Task<List<HostInfo>> ReadAsync()
        {
            using (var sr = new StreamReader(filepath))
            {
                var json = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<HostInfo>>(json);
            }
        }
    }
}
