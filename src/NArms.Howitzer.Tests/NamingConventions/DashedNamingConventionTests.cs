using NArms.Howitzer.NamingConventions;

namespace NArms.Howitzer.Tests.NamingConventions
{
    using NUnit.Framework;

    public class DashedNamingConventionTests
    {
        [Test]
        public void InvokeToApplyConvertsFromPascalCaseToDashed()
        {
            const string sourceName = "PascalCaseName";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual("pascal-case-name", name);
        }

        [Test]
        public void InvokeToApplyConvertsFromMixedCaseToDashed()
        {
            const string sourceName = "mixedCaseName";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual("mixed-case-name", name);
        }

        [Test]
        public void InvokeToApplyConvertsFromUnderscoredToDashed()
        {
            const string sourceName = "underscored_name";

            var namingConvention = new DashedNamingConvention();
            var name = namingConvention.Apply(sourceName);

            Assert.AreEqual("underscored-name", name);
        }
    }
}