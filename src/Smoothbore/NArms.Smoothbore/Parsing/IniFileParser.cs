namespace NArms.Smoothbore.Parsing
{
    using System.Collections.Generic;
    using System.IO;

    internal class IniFileParser
    {
        public IEnumerable<IniElement> Parse(TextReader textReader)
        {
            return Parse(textReader, ParseOptions.Empty);
        }

        public IEnumerable<IniElement> Parse(TextReader textReader, ParseOptions parseOptions)
        {
            var result = new List<IniElement>();

            while (true)
            {
                var line = textReader.ReadLine();
                if (line == null)
                    break;

                if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
                    continue;

                if (line.Contains("="))
                {
                    var lineParts = line.Split(new[] {'='}, 2);
                    var parameterName = lineParts[0];
                    var parameterValue = lineParts[1];

                    if (parameterValue.Contains(";"))
                        parameterValue = parameterValue.Split(';')[0];

                    result.Add(new IniParameter(parameterName.Trim(), parameterValue.Trim()));
                }                
            }

            return result;
        }
    }
}