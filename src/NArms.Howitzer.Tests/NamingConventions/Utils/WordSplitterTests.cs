using System.Collections.Generic;
using System.Linq;
using NArms.Howitzer.NamingConventions.Utils;
using Xunit;

namespace NArms.Howitzer.Tests.NamingConventions.Utils
{
    public class WordSplitterTests
    {
        [Fact]
        public void ShouldSplitPascalCaseNameCorrectCount()
        {
            const string source = "PascalCaseTestName";

            var words = WordSplitter.Split(source);
            
            Assert.Equal(4, words.Count());
        }

        [Fact]
        public void ShouldSplitPascalCaseNameCorrectWords()
        {
            const string source = "PascalCaseTestName";

            var words = WordSplitter.Split(source);
            var wordsList = new List<string>(words);

            Assert.Equal("Pascal", wordsList[0]);
            Assert.Equal("Case", wordsList[1]);
            Assert.Equal("Test", wordsList[2]);
            Assert.Equal("Name", wordsList[3]);
        }

        [Fact]
        public void ShouldSplitMixedCaseNameCorrectCount()
        {
            const string source = "mixedCaseTestName";

            var words = WordSplitter.Split(source);

            Assert.Equal(4, words.Count());
        }

        [Fact]
        public void ShouldSplitMixedCaseNameCorrectWords()
        {
            const string source = "mixedCaseTestName";

            var words = WordSplitter.Split(source);
            var wordsList = new List<string>(words);

            Assert.Equal("mixed", wordsList[0]);            
            Assert.Equal("Case", wordsList[1]);
            Assert.Equal("Test", wordsList[2]);
            Assert.Equal("Name", wordsList[3]);
        }

        [Fact]
        public void ShouldSplitUnderscoredNamesCorrectCount()
        {
            const string source = "underscored_test_name";

            var words = WordSplitter.Split(source, '_');

            Assert.Equal(3, words.Count());
        }

        [Fact]
        public void ShouldSplitUnderscoredNamesCorrectWords()
        {
            const string source = "underscored_test_name";

            var words = WordSplitter.Split(source, '_');
            var wordsList = new List<string>(words);

            Assert.Equal("underscored", wordsList[0]);
            Assert.Equal("test", wordsList[1]);
            Assert.Equal("name", wordsList[2]);
        }

        [Fact]
        public void ShouldSplitUnderscoredNamesCorrectWhileAllWordsIsUppercased()
        {
            const string source = "UNDERSCORED_TEST_NAME";

            var words = WordSplitter.Split(source, '_');
            var wordsList = new List<string>(words);

            Assert.Equal("UNDERSCORED", wordsList[0]);
            Assert.Equal("TEST", wordsList[1]);
            Assert.Equal("NAME", wordsList[2]);
        }
    }
}