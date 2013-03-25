namespace NArms.Gunbarrel.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class InterpreterTests
    {
        private class TestLanguageMetadata : LanguageMetadata
        {
        }

        [Test]
        public void CanCreateCustomInterpreterUsingLanguageMetadata()
        {
            var metadata = new TestLanguageMetadata();
            var interpreter = Interpreter.CreateFor(metadata);

            Assert.AreEqual(metadata, interpreter.LanguageMetadata);
        }
    }
}