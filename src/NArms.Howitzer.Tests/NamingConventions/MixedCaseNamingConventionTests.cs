using NArms.Howitzer.NamingConventions;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions
{
    public class MixedCaseNamingConventionTests
    {
        [Fact]
        public void InvokeToApplyShouldLeaveMixedCaseNameUnmodified()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new MixedCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal(sourceName, name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromPascalCaseToMixedCase()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new MixedCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("pascalCaseName", name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromUnderscoredCaseToMixedCase()
        {
            const string sourceName = "underscored_case_name";

            var namingConvention = new MixedCaseNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("underscoredCaseName", name);
        }
    }
}