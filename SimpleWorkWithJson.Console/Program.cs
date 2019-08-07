using Ninject;
using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Services;
using System;
using System.IO;
using System.Linq;

namespace SimpleWorkWithJson.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CompositionRoot.Register();

            var container = CompositionRoot.GetKernel();
            var service = container.Get<IHostInfoService>();

            service.AnalyzeHostsAsync().Wait();
            Console.ReadKey();
        }
    }
}
