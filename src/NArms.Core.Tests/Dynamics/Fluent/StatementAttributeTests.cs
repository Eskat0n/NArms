using NArms.Dynamics.Fluent;
using Xunit;

namespace NArms.Core.Dynamics.Fluent
{
    public class StatementAttributeTests
    {
        [Fact]
        public void ShouldMatchStatementToPattern()
        {
            var attribute = new StatementAttribute(@"t\wst");

            Assert.True(attribute.IsMatch("test"));
        }

        [Fact]
        public void ShouldCorrectlyExtractParameters()
        {
            var attribute = new StatementAttribute(@"There (\w+) parameter: (\d+)");

            var parameters = attribute.ExtractParameters("There one parameter: 15");

            Assert.NotNull(parameters);
            Assert.Equal(2, parameters.Length);
            Assert.Equal("one", parameters[0]);
            Assert.Equal("15", parameters[1]);
        }
    }
}