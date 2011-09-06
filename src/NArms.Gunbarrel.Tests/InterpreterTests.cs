using Xunit;

namespace NArms.Gunbarrel.Tests
{
    public class InterpreterTests
    {
        private class TestLanguageMetadata : LanguageMetadata
        {
        }

        [Fact]
        public void CanCreateCustomInterpreterUsingLanguageMetadata()
        {
            var metadata = new TestLanguageMetadata();
            var interpreter = Interpreter.CreateFor(metadata);

            Assert.Equal(metadata, interpreter.LanguageMetadata);
        }
    }
}