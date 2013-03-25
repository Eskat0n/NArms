namespace NArms.Appflow.Tests.ArgumentDriven.Configurations
{
    using Appflow.ArgumentDriven.Configurations;
    using NUnit.Framework;

    [TestFixture]
    public class FlagArgumentConfigurationTests
    {
        [Test]
        public void ShouldReturnTrueIfThereIsEmptyString()
        {
            var configuration = new FlagArgumentConfiguration("test");
            var value = (bool) configuration.GetValue(string.Empty);

            Assert.True(value);
        }
    }
}