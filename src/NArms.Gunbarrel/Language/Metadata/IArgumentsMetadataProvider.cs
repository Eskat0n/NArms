namespace NArms.Gunbarrel.Language.Metadata
{
    public interface IArgumentsMetadataProvider
    {
        IArgumentsMetadata None { get; }
        IArgumentsMetadata Variable { get; }
        IArgumentsMetadata MoreThan(int minArgumentsCount);
    }
}