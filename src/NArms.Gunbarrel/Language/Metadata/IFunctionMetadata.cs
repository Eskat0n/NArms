namespace NArms.Gunbarrel.Language.Metadata
{
    public interface IFunctionMetadata
    {
        IFunctionMetadata Arguments(IArgumentsMetadata moreThanOne);
        IFunctionMetadata Arguments(int argumentsNumber);      
    }
}