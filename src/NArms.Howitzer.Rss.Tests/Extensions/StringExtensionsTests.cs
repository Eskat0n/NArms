using NArms.Howitzer.Rss.Extensions;

namespace NArms.Howitzer.Rss.Tests.Extensions
{
    using NUnit.Framework;

    public class StringExtensionsTests
    {
        [Test]
        public void CallToCdataExtensionMethodShouldEncloseInCdataTag()
        {
            const string source = "Test value";

            Assert.AreEqual("<![CDATA[Test value]]>", source.Cdata());
        }
    }
}