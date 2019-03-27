using System;
using System.Runtime.Serialization;

namespace Bank2
{
    [Serializable]
    internal class AccountNotFountExecption : Exception
    {
        public AccountNotFountExecption()
        {
        }

        public AccountNotFountExecption(string message) : base(message)
        {
        }

        public AccountNotFountExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNotFountExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}