using Moq;
using SimpleWorkWithJson.DataAccess;
using SimpleWorkWithJson.Domain.Contracts;
using SimpleWorkWithJson.Domain.Models;
using SimpleWorkWithJson.Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xTests
{
    public class HostInfoServiceTest
    {
        [Fact]
        public async Task AnalyzeOneHostReturnSuccess()
        {
            // arrange
            var hi = new HostInfo()
            {
                Url = "https://rambler.ru"
            };
            var data = new List<HostInfo>() { hi };

            var moqWriter = new Mock<IHostInfoWriter>();
            var moqLogger = new Mock<ILoggerFacade>();

            var moqReader = new Mock<IHostInfoReader>();
            moqReader
                .Setup(x => x.ReadAsync())
                .Returns(Task.FromResult(data));

            var moqResolver = new Mock<IIpResolver>();
            moqResolver
                .Setup(x => x.ResolveIpAsync(hi))
                .Returns(Task.FromResult(hi));

            var service = new HostInfoService(moqReader.Object, moqWriter.Object, moqResolver.Object, moqLogger.Object);

            // act
            var res = await service.AnalyzeHostsAsync();

            // assert
            moqLogger.VerifyNoOtherCalls();
            Assert.Equal(1, res.SuccessAnalyzedHostCount);
            Assert.True(res.HostInfoSuccessSaved);
        }

        [Fact]
        public async Task AnalyzeTreeHostReturnSuccessTwo()
        {
            // arrange
            var goodHost1 = new HostInfo()
            {
                Url = "https://rambler.ru"
            };
            var goodHost2 = new HostInfo()
            {
                Url = "https://goodhost.ru"
            };
            var badHost = new HostInfo()
            {
                Url = "https://badhost.rrr"
            };
            var data = new List<HostInfo>() { goodHost1, goodHost2, badHost };

            var moqWriter = new Mock<IHostInfoWriter>();
            var moqLogger = new Mock<ILoggerFacade>();

            var moqReader = new Mock<IHostInfoReader>();
            moqReader
                .Setup(x => x.ReadAsync())
                .Returns(Task.FromResult(data));

            var moqResolver = new Mock<IIpResolver>();
            moqResolver
                .Setup(x => x.ResolveIpAsync(goodHost1))
                .Returns(Task.FromResult(goodHost1));
            moqResolver
                .Setup(x => x.ResolveIpAsync(goodHost2))
                .Returns(Task.FromResult(goodHost2));
            moqResolver
                .Setup(x => x.ResolveIpAsync(badHost))
                .ThrowsAsync(new SocketException());

            var service = new HostInfoService(moqReader.Object, moqWriter.Object, moqResolver.Object, moqLogger.Object);

            // act
            var res = await service.AnalyzeHostsAsync();

            // assert
            Assert.Equal(3, res.HostsCount);
            Assert.Equal(2, res.SuccessAnalyzedHostCount);
            Assert.True(res.HostInfoSuccessSaved);
        }

        [Fact]
        public async Task JsonNotFoundReturnZero()
        {
            // arrange
            var ex = new FileNotFoundException();
            var moqWriter = new Mock<IHostInfoWriter>();
            var moqLogger = new Mock<ILoggerFacade>();
            var moqResolver = new Mock<IIpResolver>();
            var moqReader = new Mock<IHostInfoReader>();
            moqReader
                .Setup(x => x.ReadAsync())
                .ThrowsAsync(ex);

            var service = new HostInfoService(moqReader.Object, moqWriter.Object, moqResolver.Object, moqLogger.Object);

            // act
            var res = await service.AnalyzeHostsAsync();

            // assert
            Assert.Equal(0, res.HostsCount);
            Assert.False(res.HostInfoSuccessSaved);
            moqLogger.Verify(x => x.Log(SimpleWorkWithJson.Domain.Enums.LogLevel.Error, "Can't analyze hosts", ex));
        }

        [Fact]
        public async Task AnalyzeOneHostBunNotSaved()
        {
            // arrange
            var hi = new HostInfo()
            {
                Url = "https://rambler.ru"
            };
            var data = new List<HostInfo>() { hi };
            var ex = new UnauthorizedAccessException();

            var moqLogger = new Mock<ILoggerFacade>();

            var moqReader = new Mock<IHostInfoReader>();
            moqReader
                .Setup(x => x.ReadAsync())
                .Returns(Task.FromResult(data));

            var moqResolver = new Mock<IIpResolver>();
            moqResolver
                .Setup(x => x.ResolveIpAsync(hi))
                .Returns(Task.FromResult(hi));

            var moqWriter = new Mock<IHostInfoWriter>();
            moqWriter
                .Setup(x => x.WriteAsync(data))
                .ThrowsAsync(ex);

            var service = new HostInfoService(moqReader.Object, moqWriter.Object, moqResolver.Object, moqLogger.Object);

            // act
            var res = await service.AnalyzeHostsAsync();

            // assert
            Assert.Equal(1, res.SuccessAnalyzedHostCount);
            Assert.False(res.HostInfoSuccessSaved);
            moqLogger.Verify(x => x.Log(SimpleWorkWithJson.Domain.Enums.LogLevel.Error, "Can't analyze hosts", ex));
        }
    }
}
