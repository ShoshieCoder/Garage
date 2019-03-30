using System;
using System.Runtime.Serialization;

namespace tests
{
    [Serializable]
    public class CarNotIntGarageException : ApplicationException
    {
        public CarNotIntGarageException()
        {
        }

        public CarNotIntGarageException(string message) : base(message)
        {
        }

        public CarNotIntGarageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CarNotIntGarageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}