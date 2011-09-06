using NArms.Appflow.ArgumentDriven.Configurations;
using Xunit;

namespace NArms.Appflow.Tests.ArgumentDriven.Configurations
{
    public class FlagArgumentConfigurationTests
    {
        [Fact]
        public void ShouldReturnTrueIfThereIsEmptyString()
        {
            var configuration = new FlagArgumentConfiguration("test");
            var value = (bool) configuration.GetValue(string.Empty);

            Assert.True(value);
        }
    }
}