using System;
using System.Runtime.Serialization;

namespace Bank2
{
    [Serializable]
    internal class CustomerAlreadyExistExecption : Exception
    {
        public CustomerAlreadyExistExecption()
        {
        }

        public CustomerAlreadyExistExecption(string message) : base(message)
        {
        }

        public CustomerAlreadyExistExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlreadyExistExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}