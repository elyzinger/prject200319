using System;
using System.Runtime.Serialization;

namespace Bank2
{
    [Serializable]
    internal class NotSameCustomerExecption : Exception
    {
        public NotSameCustomerExecption()
        {
        }

        public NotSameCustomerExecption(string message) : base(message)
        {
        }

        public NotSameCustomerExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSameCustomerExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}