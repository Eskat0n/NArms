using System;
using NArms.Compiling.Exceptions;
using Xunit;

namespace NArms.Compiling.Tests
{
    public class CompilingExtensionsTests
    {
        // TODO: fix tests
        [Fact(Skip = "Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForAriphmeticalExpression()
        {
            var result = (int) "2+2".Eval();

            Assert.Equal(4, result);
        }

        // TODO: fix tests
        [Fact(Skip = "Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForFormattingExpression()
        {
            var result = (string) "DateTime.Now.ToString(\"D\")".Eval();

            Assert.Equal(DateTime.Now.ToString("D"), result);
        }

        // TODO: fix tests
        [Fact(Skip = "Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForExpressionWithSemicolon()
        {
            var result = (int) "5*10;".Eval();

            Assert.Equal(50, result);
        }

        [Fact]
        public void ShouldNotCompileExpressionWithMoreThanOneStatement()
        {
            Assert.Throws<CompilingErrorsException>(() => "5 + 6; 7 + 8;".Eval());
        }
    }
}