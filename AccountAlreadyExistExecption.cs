using System;
using System.Runtime.Serialization;

namespace Bank2
{
    [Serializable]
    internal class AccountAlreadyExistExecption : Exception
    {
        public AccountAlreadyExistExecption()
        {
        }

        public AccountAlreadyExistExecption(string message) : base(message)
        {
        }

        public AccountAlreadyExistExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountAlreadyExistExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}