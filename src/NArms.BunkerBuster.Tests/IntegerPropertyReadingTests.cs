namespace NArms.BunkerBuster.Tests
{
    using Annotations;
    using NUnit.Framework;

    public class IntegerPropertyReadingTests
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
            public string NonExistentOptionalProperty { get; set; }

            [ConfigDefault("NonExistentDefaultValueProperty default value")]
            public string NonExistentDefaultValueProperty { get; set; }

            [ConfigDefault("ExistentDefaultValueProperty default value")]
            public string ExistentDefaultValueProperty { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            _config = new Config();
        } 
    }
}