using NArms.Howitzer.NamingConventions;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions
{
    public class PascalCaseNamingConventionTests
    {
        [Fact]
        public void InvokeToApplyShouldLeavePascalCaseNameUnmodified()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new PascalCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal(sourceName, name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromMixedCaseToPascalCase()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new PascalCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("MixedCaseName", name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromUnderscoredCaseToPascalCase()
        {
            const string sourceName = "underscored_case_name";

            var namingConvention = new PascalCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("UnderscoredCaseName", name);
        }
    }
}