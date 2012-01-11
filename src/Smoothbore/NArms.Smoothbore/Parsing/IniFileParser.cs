namespace NArms.Smoothbore.Parsing
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    internal class IniFileParser
    {
        private const string SectionPattern = @"\[([^\]]+)\]";

        public IEnumerable<IniElement> Parse(TextReader textReader)
        {
            return Parse(textReader, ParseOptions.Empty);
        }

        public IEnumerable<IniElement> Parse(TextReader textReader, ParseOptions parseOptions)
        {
            var result = new List<IniElement>();
            IniSection currentSection = null;

            while (true)
            {
                var line = textReader.ReadLine();
                if (line == null)
                    break;

                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith(";"))
                    continue;

                var sectionMatch = Regex.Match(line, SectionPattern);

                if (sectionMatch.Success)
                {
                    currentSection = new IniSection(sectionMatch.Groups[1].Value);
                    result.Add(currentSection);
                }
                else if (line.Contains("="))
                {
                    var lineParts = line.Split(new[] {'='}, 2);
                    var parameterName = lineParts[0];
                    var parameterValue = lineParts[1];

                    if (parameterValue.Contains(";"))
                        parameterValue = parameterValue.Split(';')[0];

                    var iniParameter = new IniParameter(parameterName.Trim(), parameterValue.Trim());

                    if (currentSection != null)
                        currentSection.AddParameter(iniParameter);
                    else
                        result.Add(iniParameter);
                }                
            }

            return result;
        }
    }
}