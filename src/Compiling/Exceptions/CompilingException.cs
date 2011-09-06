using System;
using System.Runtime.Serialization;

namespace NArms.Compiling.Exceptions
{
    public class CompilingException : Exception
    {
        public CompilingException()
        {
        }

        public CompilingException(string message)
            : base(message)
        {
        }

        public CompilingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CompilingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}