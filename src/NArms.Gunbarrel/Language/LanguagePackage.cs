using System.Collections.Generic;
using NArms.Gunbarrel.Internal;
using NArms.Gunbarrel.Language.Metadata;
using NArms.Gunbarrel.Language.Metadata.Arguments;
using NArms.Gunbarrel.Language.Metadata.Functions;

namespace NArms.Gunbarrel.Language
{
    public abstract class LanguagePackage
    {
        private readonly ICollection<FunctionMetadata> _functions = new List<FunctionMetadata>();

        protected LanguagePackage()
        {
            Arguments = new ArgumentsMetadataProvider();
            PackageManager.RegisterPackage(this);
        }

        protected IFunctionMetadata Function(string functionName)
        {
            var functionMetadata = new FunctionMetadata(functionName);
            _functions.Add(functionMetadata);
            return functionMetadata;
        }

        protected IArgumentsMetadataProvider Arguments { get; private set; }
    }
}