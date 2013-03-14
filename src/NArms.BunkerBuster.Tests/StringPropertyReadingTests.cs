namespace NArms.BunkerBuster.Tests
{
    using Annotations;
    using NUnit.Framework;

    [TestFixture]
    public class StringPropertyReadingTests
    {
        private class Config : ConfigBase
        {
            public string StringProperty { get; set; }

            [ConfigKeyName("StringProperty")]
            public string SameStringProperty { get; set; }
        }

        [Test]
        public void ShouldBeAbleToReadStringProperty()
        {
            var config = new Config();

            Assert.AreEqual("StringProperty test value", config.StringProperty);
        }
    }
}