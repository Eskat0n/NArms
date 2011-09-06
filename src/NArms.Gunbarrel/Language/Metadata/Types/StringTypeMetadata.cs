using System;
using System.Collections.Generic;
using NArms.Gunbarrel.Language.Metadata.Enclosers;

namespace NArms.Gunbarrel.Language.Metadata.Types
{
    public class StringTypeMetadata : IStringTypeMetadata
    {
        private readonly ICollection<EncloserMetadata> _enclosersMetadatas = new List<EncloserMetadata>();

        public StringLiningType StringLiningType { get; private set; }
        public IEnumerable<EncloserMetadata> EnclosersMetadatas
        {
            get { return _enclosersMetadatas; }
        }

        public IStringTypeMetadata AllowMultiline
        {
            get
            {
                StringLiningType = StringLiningType.Multiline;
                return this;
            }
        }

        public IStringTypeMetadata SingleLineOnly
        {
            get
            {
                StringLiningType = StringLiningType.SingleLine;
                return this;
            }
        }

        public IStringTypeMetadata Enclosers(string encloser)
        {
            return this;
        }

        public IStringTypeMetadata Enclosers(string begin, string end)
        {
            return this;
        }
    }

    public interface IStringTypeMetadata
    {
        IStringTypeMetadata AllowMultiline { get; }

        IStringTypeMetadata SingleLineOnly { get; }

        IStringTypeMetadata Enclosers(string encloser);

        IStringTypeMetadata Enclosers(string begin, string end);
    }

    public enum StringLiningType
    {
        SingleLine = 1,
        Multiline = 2
    }
}