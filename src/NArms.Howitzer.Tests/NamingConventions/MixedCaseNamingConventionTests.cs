namespace NArms.Howitzer.Tests.NamingConventions
{
    using Howitzer.NamingConventions;
    using NUnit.Framework;

    public class MixedCaseNamingConventionTests
    {
        [Test]
        public void InvokeToApplyShouldLeaveMixedCaseNameUnmodified()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new MixedCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual(sourceName, name);
        }

        [Test]
        public void InvokeToApplyConvertsFromPascalCaseToMixedCase()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new MixedCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual("pascalCaseName", name);
        }

        [Test]
        public void InvokeToApplyConvertsFromUnderscoredCaseToMixedCase()
        {
            const string sourceName = "underscored_case_name";

            var namingConvention = new MixedCaseNamingConvention();
            string name = namingConvention.Apply(sourceName);

            Assert.AreEqual("underscoredCaseName", name);
        }
    }
}