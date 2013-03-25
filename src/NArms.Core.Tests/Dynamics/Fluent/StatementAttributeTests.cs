using NArms.Dynamics.Fluent;

namespace NArms.Core.Dynamics.Fluent
{
    using NUnit.Framework;

    [TestFixture]
    public class StatementAttributeTests
    {
        [Test]
        public void ShouldMatchStatementToPattern()
        {
            var attribute = new StatementAttribute(@"t\wst");

            Assert.True(attribute.IsMatch("test"));
        }

        [Test]
        public void ShouldCorrectlyExtractParameters()
        {
            var attribute = new StatementAttribute(@"There (\w+) parameter: (\d+)");

            var parameters = attribute.ExtractParameters("There one parameter: 15");

            Assert.NotNull(parameters);
            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual("one", parameters[0]);
            Assert.AreEqual("15", parameters[1]);
        }
    }
}