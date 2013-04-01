using System;
using NArms.Compiling.Exceptions;

namespace NArms.Compiling.Tests
{
    using NUnit.Framework;

    public class CompilingExtensionsTests
    {
        // TODO: fix tests
        [Test]
        [Ignore("Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForAriphmeticalExpression()
        {
            var result = (int) "2+2".Eval();

            Assert.AreEqual(4, result);
        }

        // TODO: fix tests
        [Test]
        [Ignore("Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForFormattingExpression()
        {
            var result = (string) "DateTime.Now.ToString(\"D\")".Eval();

            Assert.AreEqual(DateTime.Now.ToString("D"), result);
        }

        // TODO: fix tests
        [Test]
        [Ignore("Developemnt of Compiling is in on-hold state")]
        public void ShouldCompileAndReturnCorrectResultForExpressionWithSemicolon()
        {
            var result = (int) "5*10;".Eval();

            Assert.AreEqual(50, result);
        }

        [Test]
        public void ShouldNotCompileExpressionWithMoreThanOneStatement()
        {
            Assert.Throws<CompilingErrorsException>(() => "5 + 6; 7 + 8;".Eval());
        }
    }
}