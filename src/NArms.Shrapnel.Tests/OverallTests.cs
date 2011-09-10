using System;
using System.Threading;
using Xunit;

namespace NArms.Shrapnel.Tests
{
    public class OverallTests
    {
        [Fact]
        public void FactMethodName()
        {
            var httpServer = new HttpServer("127.0.0.1");
            httpServer.Listen();

            Thread.Sleep(1000 * 3600);
        }
    }
}
