using System.Text;
using Xunit;

namespace NArms.Howitzer.Tests
{
    public class XmlMarkupDeclarationTests
    {
        [Fact]
        public void InvokeDeclarationCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_();

            Assert.Equal("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", sb.ToString());
        }

        [Fact]
        public void InvokeDeclarationWithCustomVersionCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(version: "0.9");

            Assert.Equal("<?xml version=\"0.9\" encoding=\"UTF-8\"?>", sb.ToString());
        }

        [Fact]
        public void InvokeDeclarationWithCustomEncodingCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(encoding: "Shift-JIS");

            Assert.Equal("<?xml version=\"1.0\" encoding=\"Shift-JIS\"?>", sb.ToString());
        }

        [Fact]
        public void InvokeDeclarationWithStandaloneCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(standalone: true);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>", sb.ToString());
        }

        [Fact]
        public void InvokeDeclarationWithFalseStandaloneCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(standalone: false);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>", sb.ToString());
        }
    }
}