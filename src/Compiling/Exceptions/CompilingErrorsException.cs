using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace NArms.Compiling.Exceptions
{
    public class CompilingErrorsException : CompilingException
    {
        private const string ErrorsMessage = "Compiling completed with errors.";

        public CompilerError[] Errors { get; private set; }

        public CompilingErrorsException(CompilerError[] errors)
            : base(ErrorsMessage)
        {
            Errors = errors;
        }

        protected CompilingErrorsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}