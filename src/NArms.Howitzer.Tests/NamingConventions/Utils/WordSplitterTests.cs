using System.Collections.Generic;
using System.Linq;
using NArms.Howitzer.NamingConventions.Utils;

namespace NArms.Howitzer.Tests.NamingConventions.Utils
{
    using NUnit.Framework;

    public class WordSplitterTests
    {
        [Test]
        public void ShouldSplitPascalCaseNameCorrectCount()
        {
            const string source = "PascalCaseTestName";

            var words = WordSplitter.Split(source);
            
            Assert.AreEqual(4, words.Count());
        }

        [Test]
        public void ShouldSplitPascalCaseNameCorrectWords()
        {
            const string source = "PascalCaseTestName";

            var words = WordSplitter.Split(source);
            var wordsList = new List<string>(words);

            Assert.AreEqual("Pascal", wordsList[0]);
            Assert.AreEqual("Case", wordsList[1]);
            Assert.AreEqual("Test", wordsList[2]);
            Assert.AreEqual("Name", wordsList[3]);
        }

        [Test]
        public void ShouldSplitMixedCaseNameCorrectCount()
        {
            const string source = "mixedCaseTestName";

            var words = WordSplitter.Split(source);

            Assert.AreEqual(4, words.Count());
        }

        [Test]
        public void ShouldSplitMixedCaseNameCorrectWords()
        {
            const string source = "mixedCaseTestName";

            var words = WordSplitter.Split(source);
            var wordsList = new List<string>(words);

            Assert.AreEqual("mixed", wordsList[0]);            
            Assert.AreEqual("Case", wordsList[1]);
            Assert.AreEqual("Test", wordsList[2]);
            Assert.AreEqual("Name", wordsList[3]);
        }

        [Test]
        public void ShouldSplitUnderscoredNamesCorrectCount()
        {
            const string source = "underscored_test_name";

            var words = WordSplitter.Split(source, '_');

            Assert.AreEqual(3, words.Count());
        }

        [Test]
        public void ShouldSplitUnderscoredNamesCorrectWords()
        {
            const string source = "underscored_test_name";

            var words = WordSplitter.Split(source, '_');
            var wordsList = new List<string>(words);

            Assert.AreEqual("underscored", wordsList[0]);
            Assert.AreEqual("test", wordsList[1]);
            Assert.AreEqual("name", wordsList[2]);
        }

        [Test]
        public void ShouldSplitUnderscoredNamesCorrectWhileAllWordsIsUppercased()
        {
            const string source = "UNDERSCORED_TEST_NAME";

            var words = WordSplitter.Split(source, '_');
            var wordsList = new List<string>(words);

            Assert.AreEqual("UNDERSCORED", wordsList[0]);
            Assert.AreEqual("TEST", wordsList[1]);
            Assert.AreEqual("NAME", wordsList[2]);
        }
    }
}