using System;
using System.Text;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupTagNestingTests
    {
        // TODO: implement this test functionality in future
        [Fact(Skip = "For implementing in future")]
        public void CanAddNestedTagsWithUsingClause()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            using (xmlMarkup.Family())
            {
                xmlMarkup.Child("Bob");
                xmlMarkup.Child("Tom");
                xmlMarkup.Child("Jerry");
            }

            var lines = sb.ToString().Split(Environment.NewLine.ToCharArray());

            Assert.Equal("<Family>", lines[0]);
            Assert.Equal("  <Child>Bob</Child>", lines[1]);
            Assert.Equal("  <Child>Tom</Child>", lines[2]);
            Assert.Equal("  <Child>Jerry</Child>", lines[3]);
            Assert.Equal("</Family>", lines[4]);
        }
    }
}