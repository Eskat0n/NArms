using System.Text;
using NArms.Howitzer.NamingConventions.Utils;

namespace NArms.Howitzer.NamingConventions
{
    public class DelimeterNamingConvention : INamingConvention
    {
        private readonly char _delimeter;

        protected DelimeterNamingConvention(char delimeter)
        {
            _delimeter = delimeter;
        }
        
        public string Apply(string source)
        {
            var name = new StringBuilder();
            var words = WordSplitter.Split(source, '_');

            foreach (var word in words)
                name.Append(word.ToLowerInvariant() + _delimeter);

            return name.ToString().TrimEnd(_delimeter);
        }
    }
}