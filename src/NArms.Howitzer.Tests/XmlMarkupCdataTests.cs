using System.Text;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupCdataTests
    {
        [Fact]
        public void CallToCdataShouldEncloseGivenTextInCdataTag()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Cdata_("Text in cdata");

            Assert.Equal("<![CDATA[Text in cdata]]>", sb.ToString());
        }
    }
}