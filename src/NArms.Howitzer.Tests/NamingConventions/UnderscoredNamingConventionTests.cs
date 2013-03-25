using NArms.Howitzer.NamingConventions;

namespace NArms.Howitzer.Tests.NamingConventions
{
    using NUnit.Framework;

    public class UnderscoredNamingConventionTests
    {
        [Test]
        public void InvokeToApplyShouldLeaveUnderscoredNameUnmodified()
        {
            const string sourceName = "underscored_name";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual(sourceName, name);
        }

        [Test]
        public void InvokeToApplyConvertsFromPascalCaseToUnderscored()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual("pascal_case_name", name);
        }

        [Test]
        public void InvokeToApplyConvertsFromMixedCaseToUnderscored()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new UnderscoredNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual("mixed_case_name", name);
        }
    }
}