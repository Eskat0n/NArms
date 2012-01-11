namespace NArms.Smoothbore.Tests
{
    using System.Linq;
    using Xunit;

    public class IniFileLoadingTests
    {
        [Fact]
        public void ShouldProcudeCorrectElementsListForSimpleFile()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.ini");
            var iniParameters = iniFile.Elements
                .OfType<IniParameter>()
                .ToArray();

            Assert.Equal(2, iniParameters.Length);
            Assert.Equal("param1", iniParameters[0].Name);
            Assert.Equal("first value", iniParameters[0].Value);
            Assert.Equal("param2", iniParameters[1].Name);
            Assert.Equal("second value", iniParameters[1].Value);            
        }
    }
}