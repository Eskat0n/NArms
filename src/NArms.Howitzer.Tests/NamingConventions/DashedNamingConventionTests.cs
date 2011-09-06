using NArms.Howitzer.NamingConventions;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions
{
    public class DashedNamingConventionTests
    {
        [Fact]
        public void InvokeToApplyConvertsFromPascalCaseToDashed()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("pascal-case-name", name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromMixedCaseToDashed()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("mixed-case-name", name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromUnderscoredToDashed()
        {
            const string sourceName = "underscored_name";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("underscored-name", name);
        }
    }
}