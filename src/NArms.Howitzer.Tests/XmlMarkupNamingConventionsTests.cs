using System.Text;
using NArms.Howitzer.NamingConventions;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupNamingConventionsTests
    {
        [Fact]
        public void TagNamingConventionShouldBePascalCaseByDefault()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            Assert.IsType<PascalCaseNamingConvention>(xmlMarkup.TagNamingConvention);
        }

        [Fact]
        public void TagNamingConventionSettingCorrect()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, tagNamingConvention: new MixedCaseNamingConvention());

            Assert.IsType<MixedCaseNamingConvention>(xmlMarkup.TagNamingConvention);
        }

        [Fact]
        public void AttributeNamingConventionShouldBeMixedCaseByDefault()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);

            Assert.IsType<MixedCaseNamingConvention>(xmlMarkup.AttributeNamingConvention);
        }

        [Fact]
        public void AttributeNamingConventionSettingCorrect()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, attributeNamingConvention: new PascalCaseNamingConvention());

            Assert.IsType<PascalCaseNamingConvention>(xmlMarkup.AttributeNamingConvention);
        }

        // TODO: fix test
        [Fact(Skip = "Developemnt of Howitzer is in on-hold state")]
        public void CustomTagNamingConventionAppliesToTags()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, tagNamingConvention: new UnderscoredNamingConvention());
            xmlMarkup.UnderscoredTagName("value");

            Assert.Equal("<underscored_tag_name>value</underscored_tag_name>", sb.ToString());
        }

        // TODO: fix test
        [Fact(Skip = "Developemnt of Howitzer is in on-hold state")]
        public void CustomAttributeConventionAppliesToAttributes()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb, attributeNamingConvention: new DashedNamingConvention());
            xmlMarkup.TestTag("", new {@dashedName = "value"});

            Assert.Equal("<TestTag dashed-name=\"value\"></TestTag>", sb.ToString());
        }
    }
}