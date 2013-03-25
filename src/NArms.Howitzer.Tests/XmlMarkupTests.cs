namespace NArms.Howitzer.Tests
{
    using System;
    using System.Text;
    using NUnit.Framework;

    public class XmlMarkupTests
    {
        [Test]
        public void CreateXmlMarkupObjectWithStringBuilderChangesApplyToBoth()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            sb.Append("Test string");

            Assert.AreEqual(sb, xmlMarkup.Target);
        }

        [Test]
        public void CreateXmlMarkupObjectWithCustomIndent()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, 5);

            Assert.AreEqual(5, xmlMarkup.Indent);
        }

        [Test]
        public void ThrowsExceptionForNegativeIndentValue()
        {
            Assert.Throws<ArgumentException>(() =>
                                                 {
                                                     var sb = new StringBuilder();
                                                     new XmlMarkup(ref sb, -1);
                                                 });
        }

        // TODO: fix test
        [Test]
        [Ignore("Developemnt of Howitzer is in on-hold state")]
        public void CanAssignValueToAnyXmlTagWithWords()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag("TestValue");

            Assert.AreEqual("<TestTag>TestValue</TestTag>", sb.ToString());
        }

        // TODO: fix test
        [Test]
        [Ignore("Developemnt of Howitzer is in on-hold state")]
        public void AssigningNoValueToAnyXmlTagCreatesEmptyTag()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag();

            Assert.AreEqual("<TestTag></TestTag>", sb.ToString());
        }

        // TODO: fix test
        [Test]
        [Ignore("Developemnt of Howitzer is in on-hold state")]
        public void CanAssignAttrubtesToTagByAnonymousObjectWithValue()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.TestTag("TestValue", new {firstAttribute = "AttributeValue"});

            Assert.AreEqual("<TestTag firstAttribute=\"AttributeValue\">TestValue</TestTag>", sb.ToString());
        }
    }
}