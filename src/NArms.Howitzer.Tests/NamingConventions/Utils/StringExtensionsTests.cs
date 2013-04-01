namespace NArms.Howitzer.Tests.NamingConventions.Utils
{
    using Howitzer.NamingConventions.Utils;
    using NUnit.Framework;

    public class StringExtensionsTests
    {
        private const string EnglishStringUpper = "THIS IS UPPER STRING";
        private const string EnglishStringLower = "this is lower string";

        [Test]
        public void IsUpperCorrectForEnglish()
        {
            Assert.True(EnglishStringUpper.IsUpper());
        }

        [Test]
        public void IsUpperCorrectFalseForEnglish()
        {
            Assert.False(EnglishStringLower.IsUpper());
        }

        [Test]
        public void IsLowerCorrectForEnglish()
        {
            Assert.True(EnglishStringLower.IsLower());
        }

        [Test]
        public void IsLowerCorrectFalseForEnglish()
        {
            Assert.False(EnglishStringUpper.IsLower());
        }

        [Test]
        public void CapitalizeCorrectForLongStrings()
        {
            const string str = "capitalize me";

            Assert.AreEqual("Capitalize me", str.Capitalize());
        }

        [Test]
        public void CapitalizeCorrectForOneCharacterStrings()
        {
            const string str = "c";

            Assert.AreEqual("C", str.Capitalize());
        }

        [Test]
        public void CapitalizationShouldMakeAllCharactersLowercaseExceptForfirst()
        {
            const string str = "capITALIZE mE";

            Assert.AreEqual("Capitalize me", str.Capitalize());
        }
    }
}