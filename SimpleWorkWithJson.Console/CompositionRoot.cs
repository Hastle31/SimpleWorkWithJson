using Ninject;
using SimpleWorkWithJson.Common.Logging;
using SimpleWorkWithJson.DataAccess;
using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleWorkWithJson.ConsoleApp
{
    /// <summary>
    /// Компоновщик зависимостей приложения.
    /// </summary>
    public static class CompositionRoot
    {
        public static readonly string DefaultJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Sample.json");

        private static readonly IKernel kernel = new StandardKernel();

        /// <summary>
        /// Получить di-контейнер.
        /// </summary>
        /// <returns></returns>
        public static IKernel GetKernel()
        {
            return kernel;
        }

        /// <summary>
        /// Зарегистрировать зависимости.
        /// </summary>
        public static void Register()
        {
            kernel.Bind<ILoggerFacade>().To<ConsoleLogger>();

            kernel
                .Bind<IHostInfoReader>()
                .To<HostInfoJsonReader>()
                .WithConstructorArgument("filepath", DefaultJsonPath);

            kernel
                .Bind<IHostInfoWriter>()
                .To<HostInfoJsonWriter>()
                .WithConstructorArgument("filepath", DefaultJsonPath);

            // В таком виде происходит регистрация декораторов в NInject.
            kernel.Bind<IIpResolver>().To<IpResolverLogDecorator>();
            kernel.Bind<IIpResolver>().To<IpResolver>().WhenInjectedInto<IpResolverLogDecorator>();

            kernel.Bind<IHostInfoService>().To<HostInfoServiceLogDecorator>();
            kernel.Bind<IHostInfoService>().To<HostInfoService>().WhenInjectedInto<HostInfoServiceLogDecorator>();
        }
    }
}
