using NArms.Howitzer.Rss.Extensions;
using Xunit;

namespace NArms.Howitzer.Rss.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void CallToCdataExtensionMethodShouldEncloseInCdataTag()
        {
            const string source = "Test value";

            Assert.Equal("<![CDATA[Test value]]>", source.Cdata());
        }
    }
}