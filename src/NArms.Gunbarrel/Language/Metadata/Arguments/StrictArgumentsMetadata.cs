namespace NArms.Gunbarrel.Language.Metadata.Arguments
{
    public class StrictArgumentsMetadata : IArgumentsMetadata
    {
        private readonly int _count;

        internal StrictArgumentsMetadata(int count)
        {
            _count = count;
        }
    }
}