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
            public string OtherStringProperty { get; set; }

            [ConfigIgnore]
            public string IgnoredStringProperty { get; set; }
        }

        [Test]
        public void ShouldBeAbleToReadStringProperty()
        {
            var config = new Config();

            Assert.AreEqual("StringProperty test value", config.StringProperty);
        }

        [Test]
        public void ShouldBeAbleToReadStringPropertyUsingOverridenKey()
        {
            var config = new Config();

            Assert.AreEqual("StringProperty test value", config.OtherStringProperty);
        }

        [Test]
        public void ShouldNotSetValueForIgnoredConfigProperty()
        {
            var config = new Config();

            Assert.IsNull(config.IgnoredStringProperty);
        }
    }
}