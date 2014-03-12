namespace NArms.Config.Tests
{
    using Config;
    using Annotations;
    using NUnit.Framework;

    [TestFixture]
    public class IntegerPropertyReadingTests
    {
        private Config _config;

        private class Config : ConfigBase
        {
            [ConfigKeyName("IntegerProperty")]
            public short ShortProperty { get; set; }

            [ConfigKeyName("IntegerProperty")]
            public ushort UShortProperty { get; set; }

            [ConfigKeyName("IntegerProperty")]
            public int IntProperty { get; set; }

            [ConfigKeyName("IntegerProperty")]
            public uint UIntProperty { get; set; }
            
            [ConfigKeyName("IntegerProperty")]
            public long LongProperty { get; set; }

            [ConfigKeyName("IntegerProperty")]
            public ulong ULongProperty { get; set; }

            public short OverflowProperty { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            _config = new Config();
        } 

        [Test]
        public void ShouldBeAbleToReadAllTypesOfIntegerProperties()
        {
            Assert.AreEqual(4321, _config.ShortProperty);
            Assert.AreEqual(4321, _config.UShortProperty);
            Assert.AreEqual(4321, _config.IntProperty);
            Assert.AreEqual(4321, _config.UIntProperty);
            Assert.AreEqual(4321, _config.LongProperty);
            Assert.AreEqual(4321, _config.ULongProperty);
        }
    }
}