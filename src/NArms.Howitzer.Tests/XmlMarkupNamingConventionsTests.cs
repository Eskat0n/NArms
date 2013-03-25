using System.Text;
using NArms.Howitzer.NamingConventions;

namespace NArms.Howitzer.Tests
{
    using NUnit.Framework;

    public class XmlMarkupNamingConventionsTests
    {
        [Test]
        public void TagNamingConventionShouldBePascalCaseByDefault()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            Assert.IsInstanceOf<PascalCaseNamingConvention>(xmlMarkup.TagNamingConvention);
        }

        [Test]
        public void TagNamingConventionSettingCorrect()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, tagNamingConvention: new MixedCaseNamingConvention());

            Assert.IsInstanceOf<MixedCaseNamingConvention>(xmlMarkup.TagNamingConvention);
        }

        [Test]
        public void AttributeNamingConventionShouldBeMixedCaseByDefault()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            Assert.IsInstanceOf<MixedCaseNamingConvention>(xmlMarkup.AttributeNamingConvention);
        }

        [Test]
        public void AttributeNamingConventionSettingCorrect()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, attributeNamingConvention: new PascalCaseNamingConvention());

            Assert.IsInstanceOf<PascalCaseNamingConvention>(xmlMarkup.AttributeNamingConvention);
        }

        // TODO: fix test
        [Test]
        [Ignore("Developemnt of Howitzer is in on-hold state")]
        public void CustomTagNamingConventionAppliesToTags()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, tagNamingConvention: new UnderscoredNamingConvention());
            xmlMarkup.UnderscoredTagName("value");

            Assert.AreEqual("<underscored_tag_name>value</underscored_tag_name>", sb.ToString());
        }

        // TODO: fix test
        [Test]
        [Ignore("Developemnt of Howitzer is in on-hold state")]
        public void CustomAttributeConventionAppliesToAttributes()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, attributeNamingConvention: new DashedNamingConvention());
            xmlMarkup.TestTag("", new {@dashedName = "value"});

            Assert.AreEqual("<TestTag dashed-name=\"value\"></TestTag>", sb.ToString());
        }
    }
}