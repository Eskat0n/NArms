namespace NArms.Smoothbore.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class IniFileLoadingTests
    {
        [Fact]
        public void ShouldProcudeCorrectElementsListForSimpleFile()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.ini");            
            VerifySimpleFileContent(iniFile.Parameters);
        }

        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithComments()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.Commented.ini");
            VerifySimpleFileContent(iniFile.Parameters);
        }                   

        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithParameterComments()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.ParameterCommented.ini");
            VerifySimpleFileContent(iniFile.Parameters);
        }
        
        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithCondensedContent()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.Condensed.ini");
            VerifySimpleFileContent(iniFile.Parameters);
        }
        
        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithIndentedComment()
        {
            var iniFile = IniFile.Load("TestFiles/Simple.CommentIndented.ini");
            VerifySimpleFileContent(iniFile.Parameters);
        }
        
        [Fact]
        public void ShouldProcudeCorrectElementsListForFileWithOneSection()
        {
            var iniFile = IniFile.Load("TestFiles/Sections.One.ini");

            var iniSections = iniFile.Sections.ToArray();
            var iniParameters = iniFile.Parameters;

            Assert.Equal(1, iniSections.Length);
            Assert.Equal(iniParameters, iniSections[0].Parameters);
            VerifySimpleFileContent(iniSections[0].Parameters);
        }

        private static void VerifySimpleFileContent(IEnumerable<IniParameter> iniParameters)
        {
            var iniParametersArray = iniParameters.ToArray();

            Assert.Equal(2, iniParametersArray.Length);
            Assert.Equal("param1", iniParametersArray[0].Name);
            Assert.Equal("first value", iniParametersArray[0].Value);
            Assert.Equal("param2", iniParametersArray[1].Name);
            Assert.Equal("second value", iniParametersArray[1].Value);
        }
    }
}