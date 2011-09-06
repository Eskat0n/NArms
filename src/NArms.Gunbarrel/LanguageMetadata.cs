using NArms.Gunbarrel.Language.Metadata.Types;

namespace NArms.Gunbarrel
{
    public abstract class LanguageMetadata
    {
        private readonly StringTypeMetadata _stringMetadata;

        protected IStringTypeMetadata Strings
        {
            get { return _stringMetadata; }
        }
    }
}