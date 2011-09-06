using System.Collections.Generic;

namespace NArms.Howitzer.NamingConventions.Utils
{
    public static class WordSplitter
    {
        private enum CharacterCase
        {
            Lower = 1,
            Upper = 2
        }

        public static IEnumerable<string> Split(string source, params char[] optionalWordSplitters)
        {
            var words = new List<string>();
            var wordSplitters = new List<char>(optionalWordSplitters) {' '};

            CharacterCase? lastCharCase = null;
            var lastWordEnd = 0;
            for (var i = 0; i < source.Length; i++)
            {
                var ch = source[i];
                if (lastCharCase != null)
                {
                    var currentCharCase = GetCharCase(ch);

                    if ((lastCharCase == CharacterCase.Lower && currentCharCase == CharacterCase.Upper)
                        || wordSplitters.Contains(ch))
                    {
                        var word = source
                            .Substring(lastWordEnd, i - lastWordEnd)
                            .Trim(optionalWordSplitters);
                        words.Add(word);
                        lastWordEnd = i;
                    }                        
                }   
             
                lastCharCase = GetCharCase(ch);
            }

            var lastWord = source
                .Substring(lastWordEnd, source.Length - lastWordEnd)
                .Trim(optionalWordSplitters);
            words.Add(lastWord);

            return words;
        }

        private static CharacterCase GetCharCase(char ch)
        {
            return ch.ToString().IsUpper()
                       ? CharacterCase.Upper
                       : CharacterCase.Lower;
        }
    }
}