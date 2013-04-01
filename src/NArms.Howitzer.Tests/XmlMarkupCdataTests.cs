using System.Text;

namespace NArms.Howitzer.Tests
{
    using NUnit.Framework;

    public class XmlMarkupCdataTests
    {
        [Test]
        public void CallToCdataShouldEncloseGivenTextInCdataTag()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Cdata_("Text in cdata");

            Assert.AreEqual("<![CDATA[Text in cdata]]>", sb.ToString());
        }
    }
}