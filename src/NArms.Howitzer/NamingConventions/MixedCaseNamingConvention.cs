using System.Text;
using NArms.Howitzer.NamingConventions.Utils;

namespace NArms.Howitzer.NamingConventions
{
    public sealed class MixedCaseNamingConvention : INamingConvention
    {
        public string Apply(string source)
        {
            var name = new StringBuilder();
            var words = WordSplitter.Split(source, '_');

            var i = 0;
            foreach (var word in words)
                name.Append(i++ == 0
                                ? word.ToLower()
                                : word.Capitalize());

            return name.ToString();
        }
    }
}