namespace NArms.Howitzer.Tests.NamingConventions
{
    using Howitzer.NamingConventions;
    using NUnit.Framework;

    public class PascalCaseNamingConventionTests
    {
        [Test]
        public void InvokeToApplyShouldLeavePascalCaseNameUnmodified()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new PascalCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual(sourceName, name);
        }

        [Test]
        public void InvokeToApplyConvertsFromMixedCaseToPascalCase()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new PascalCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual("MixedCaseName", name);
        }

        [Test]
        public void InvokeToApplyConvertsFromUnderscoredCaseToPascalCase()
        {
            const string sourceName = "underscored_case_name";

            var namingConvention = new PascalCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual("UnderscoredCaseName", name);
        }
    }
}