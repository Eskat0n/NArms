using NArms.Howitzer.NamingConventions;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions
{
    public class UnderscoredNamingConventionTests
    {
        [Fact]
        public void InvokeToApplyShouldLeaveUnderscoredNameUnmodified()
        {
            const string sourceName = "underscored_name";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal(sourceName, name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromPascalCaseToUnderscored()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("pascal_case_name", name);
        }

        [Fact]
        public void InvokeToApplyConvertsFromMixedCaseToUnderscored()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.Equal("mixed_case_name", name);
        }
    }
}