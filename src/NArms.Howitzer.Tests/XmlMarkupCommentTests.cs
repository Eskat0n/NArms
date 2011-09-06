using System.Text;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupCommentTests
    {
        [Fact]
        public void CallToCommentShouldEncloseGivenTextInComment()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Comment_("This is a comment");

            Assert.Equal("<!--This is a comment-->", sb.ToString());
        }
    }
}