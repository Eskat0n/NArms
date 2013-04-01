using System;
using System.Text;

namespace NArms.Howitzer.Tests
{
    using NUnit.Framework;

    public class XmlMarkupTagNestingTests
    {
        // TODO: implement this test functionality in future
        [Test]
        [Ignore("For implementing in future")]
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

            Assert.AreEqual("<Family>", lines[0]);
            Assert.AreEqual("  <Child>Bob</Child>", lines[1]);
            Assert.AreEqual("  <Child>Tom</Child>", lines[2]);
            Assert.AreEqual("  <Child>Jerry</Child>", lines[3]);
            Assert.AreEqual("</Family>", lines[4]);
        }
    }
}