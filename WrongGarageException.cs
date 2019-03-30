using System;
using System.Runtime.Serialization;

namespace tests
{
    [Serializable]
    public class WrongGarageException : ApplicationException
    {
        public WrongGarageException()
        {
        }

        public WrongGarageException(string message) : base(message)
        {
        }

        public WrongGarageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongGarageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}