namespace NArms.BunkerBuster.Tests
{
    using Annotations;
    using NUnit.Framework;

    [TestFixture]
    public class StringPropertyReadingTests
    {
        private Config _config;

        private class Config : ConfigBase
        {
            public string StringProperty { get; set; }

            [ConfigKeyName("StringProperty")]
            public string OtherStringProperty { get; set; }

            [ConfigIgnore]
            public string IgnoredStringProperty { get; set; }

            [ConfigOptional]
            public string ExistentOptionalProperty { get; set; }

            [ConfigOptional]
            public object NonExistentOptionalProperty { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            _config = new Config();
        }

        [Test]
        public void ShouldBeAbleToReadStringProperty()
        {
            Assert.AreEqual("StringProperty test value", _config.StringProperty);
        }

        [Test]
        public void ShouldBeAbleToReadStringPropertyUsingOverridenKey()
        {
            Assert.AreEqual("StringProperty test value", _config.OtherStringProperty);
        }

        [Test]
        public void ShouldNotSetValueForIgnoredConfigProperty()
        {
            Assert.IsNull(_config.IgnoredStringProperty);
        }

        [Test]
        public void ShouldReturnNullValueForNonExistentOptionalProperty()
        {
            Assert.IsNull(_config.NonExistentOptionalProperty);
        }
        
        [Test]
        public void ShouldSetValueForExistentOptionalProperty()
        {
            Assert.AreEqual("ExistentOptionalProperty test value", _config.ExistentOptionalProperty);
        }
    }
}