using System;
using System.Text;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupTests
    {
        [Fact]
        public void CreateXmlMarkupObjectWithStringBuilderChangesApplyToBoth()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            sb.Append("Test string");

            Assert.Equal(sb, xmlMarkup.Target);
        }

        [Fact]
        public void CreateXmlMarkupObjectWithCustomIndent()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, 5);

            Assert.Equal(5, xmlMarkup.Indent);
        }

        [Fact]
        public void ThrowsExceptionForNegativeIndentValue()
        {
            Assert.Throws<ArgumentException>(() =>
                                                 {
                                                     var sb = new StringBuilder();
                                                     new XmlMarkup(ref sb, -1);
                                                 });
        }

        // TODO: fix test
        [Fact(Skip = "Developemnt of Howitzer is in on-hold state")]
        public void CanAssignValueToAnyXmlTagWithWords()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag("TestValue");

            Assert.Equal("<TestTag>TestValue</TestTag>", sb.ToString());
        }

        // TODO: fix test
        [Fact(Skip = "Developemnt of Howitzer is in on-hold state")]
        public void AssigningNoValueToAnyXmlTagCreatesEmptyTag()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag();

            Assert.Equal("<TestTag></TestTag>", sb.ToString());
        }

        // TODO: fix test
        [Fact(Skip = "Developemnt of Howitzer is in on-hold state")]
        public void CanAssignAttrubtesToTagByAnonymousObjectWithValue()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag("TestValue", new {firstAttribute = "AttributeValue"});

            Assert.Equal("<TestTag firstAttribute=\"AttributeValue\">TestValue</TestTag>", sb.ToString());
        }
    }
}