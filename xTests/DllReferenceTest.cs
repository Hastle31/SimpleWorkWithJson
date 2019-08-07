using SimpleWorkWithJson.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace xTests
{
    public class DllReferenceTest
    {
        /// <summary>
        /// Библиотека Domain не должна зависеть от DataAccess.
        /// </summary>
        [Fact]
        public void DomainLibraryIndepended()
        {
            var type = typeof(IHostInfoService);
            var referencesAssembly = type.Assembly
                .GetReferencedAssemblies()
                .Where(x => x.Name.StartsWith("SimpleWorkWithJson"));
            Assert.Empty(referencesAssembly);
        }
    }
}
