namespace NArms.Smoothbore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Parsing;

    public class IniFile
    {
        private readonly IList<IniElement> _elements = new List<IniElement>();

        public static IniFile Load(string filename)
        {
            using (var fileStream = File.OpenRead(filename))
                return Load(fileStream);
        }
        
        public static IniFile Load(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
                return Load(streamReader);
        }

        public static IniFile Load(TextReader textReader)
        {
            var parser = new IniFileParser();
            return new IniFile(parser.Parse(textReader));
        }

        public IniFile()
        {
        }

        public IniFile(IEnumerable<IniElement> elements)
        {
            foreach (var element in elements)
                _elements.Add(element);
        }

        public IEnumerable<IniElement> Elements
        {
            get { return _elements; }
        }
        
        public IEnumerable<IniSection> Sections
        {
            get
            {
                return _elements
                    .OfType<IniSection>()
                    .ToArray();
            }
        }
        
        public IEnumerable<IniParameter> Parameters
        {
            get
            {
                var sectionParameters = Elements.OfType<IniSection>()
                    .SelectMany(x => x.Parameters);

                return _elements
                    .OfType<IniParameter>()
                    .Union(sectionParameters)
                    .ToArray();
            }
        }

        public void Save(string filename)
        {
            throw new NotImplementedException();
        }
        
        public void Save(Stream stream)
        {
            throw new NotImplementedException();
        }
        
        public void Save(TextWriter textWriter)
        {
            throw new NotImplementedException();
        }
    }
}