using System.Text;
using NArms.Howitzer.NamingConventions.Utils;

namespace NArms.Howitzer.NamingConventions
{
    public sealed class PascalCaseNamingConvention : INamingConvention
    {
        public string Apply(string source)
        {
            var name = new StringBuilder();
            var words = WordSplitter.Split(source, '_');

            foreach (var word in words)
                name.Append(word.Capitalize());

            return name.ToString();
        }
    }
}