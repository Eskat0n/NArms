using System;
using NArms.Gunbarrel.Language.Metadata.Arguments;

namespace NArms.Gunbarrel.Language.Metadata.Functions
{
    public class FunctionMetadata : IFunctionMetadata
    {
        private readonly string _functionName;
        private IArgumentsMetadata _argumentsMetadata;

        internal FunctionMetadata(string functionName)
        {
            _functionName = functionName.Trim();

            if (_functionName.Contains(" "))
                // TODO: replace exception with custom exception
                throw new Exception();
        }

        public IFunctionMetadata Arguments(IArgumentsMetadata argumentsMetadata)
        {
            _argumentsMetadata = argumentsMetadata;
            return this;
        }

        public IFunctionMetadata Arguments(int argumentsNumber)
        {
            _argumentsMetadata = new StrictArgumentsMetadata(argumentsNumber);
            return this;
        }
    }
}