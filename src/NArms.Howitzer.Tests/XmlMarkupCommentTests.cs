using System.Text;

namespace NArms.Howitzer.Tests
{
    using NUnit.Framework;

    public class XmlMarkupCommentTests
    {
        [Test]
        public void CallToCommentShouldEncloseGivenTextInComment()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Comment_("This is a comment");

            Assert.AreEqual("<!--This is a comment-->", sb.ToString());
        }
    }
}