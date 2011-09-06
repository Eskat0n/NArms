using NArms.Surgery.Dynamic;
using Xunit;

namespace NArms.Surgery.Tests.Dynamic
{
    public class DissectionExtensionsTests
    {
        private class Stub
        {            
        }

        [Fact]
        public void CallToDissectionReturnsProxyWithCorrectTarget()
        {
            var stub = new Stub();
            object proxy = stub.Dissect();

            Assert.IsType<DynamicProxy<Stub>>(proxy);
        }
    }
}