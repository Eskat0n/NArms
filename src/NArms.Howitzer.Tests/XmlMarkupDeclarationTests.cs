using System.Text;

namespace NArms.Howitzer.Tests
{
    using NUnit.Framework;

    public class XmlMarkupDeclarationTests
    {
        [Test]
        public void InvokeDeclarationCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_();

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", sb.ToString());
        }

        [Test]
        public void InvokeDeclarationWithCustomVersionCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(version: "0.9");

            Assert.AreEqual("<?xml version=\"0.9\" encoding=\"UTF-8\"?>", sb.ToString());
        }

        [Test]
        public void InvokeDeclarationWithCustomEncodingCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(encoding: "Shift-JIS");

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"Shift-JIS\"?>", sb.ToString());
        }

        [Test]
        public void InvokeDeclarationWithStandaloneCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(standalone: true);

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>", sb.ToString());
        }

        [Test]
        public void InvokeDeclarationWithFalseStandaloneCreatesValidXmlDeclaration()
        {
            var sb = new StringBuilder();

            dynamic xmlMarkup = new XmlMarkup(ref sb);
            xmlMarkup.Declaration_(standalone: false);

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>", sb.ToString());
        }
    }
}