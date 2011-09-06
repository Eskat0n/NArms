namespace NArms.Gunbarrel.Language.Metadata.Arguments
{
    public class ArgumentsMetadataProvider : IArgumentsMetadataProvider
    {
        internal ArgumentsMetadataProvider()
        {
        }

        public IArgumentsMetadata None
        {
            get { return new NoneArgumentsMetadata(); }
        }

        public IArgumentsMetadata Variable
        {
            get { return new VariantArgumentsMetadata(); }
        }

        public IArgumentsMetadata MoreThan(int minArgumentsCount)
        {
            return new MoreThanArgumentsMetadata();
        }
    }
}