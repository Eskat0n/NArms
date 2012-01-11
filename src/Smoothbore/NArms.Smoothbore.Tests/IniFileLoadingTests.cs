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
            VerifySimpleFileContent(iniFile);
        }

        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithComments()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.Commented.ini");
            VerifySimpleFileContent(iniFile);
        }

        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithParameterComments()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.ParameterCommented.ini");
            VerifySimpleFileContent(iniFile);
        }
        
        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithCondensedContent()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.Condensed.ini");
            VerifySimpleFileContent(iniFile);
        }

        private static void VerifySimpleFileContent(IniFile iniFile)
        {
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