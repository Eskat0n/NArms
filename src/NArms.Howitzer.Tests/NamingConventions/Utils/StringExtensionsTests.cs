using NArms.Howitzer.NamingConventions.Utils;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions.Utils
{
    public class StringExtensionsTests
    {
        private const string EnglishStringUpper = "THIS IS UPPER STRING";
        private const string EnglishStringLower = "this is lower string";

        [Fact]
        public void IsUpperCorrectForEnglish()
        {
            Assert.True(EnglishStringUpper.IsUpper());
        }

        [Fact]
        public void IsUpperCorrectFalseForEnglish()
        {
            Assert.False(EnglishStringLower.IsUpper());
        }

        [Fact]
        public void IsLowerCorrectForEnglish()
        {
            Assert.True(EnglishStringLower.IsLower());
        }

        [Fact]
        public void IsLowerCorrectFalseForEnglish()
        {
            Assert.False(EnglishStringUpper.IsLower());
        }

        [Fact]
        public void CapitalizeCorrectForLongStrings()
        {
            const string str = "capitalize me";

            Assert.Equal("Capitalize me", str.Capitalize());
        }

        [Fact]
        public void CapitalizeCorrectForOneCharacterStrings()
        {
            const string str = "c";

            Assert.Equal("C", str.Capitalize());
        }

        [Fact]
        public void CapitalizationShouldMakeAllCharactersLowercaseExceptForfirst()
        {
            const string str = "capITALIZE mE";

            Assert.Equal("Capitalize me", str.Capitalize());
        }
    }
}