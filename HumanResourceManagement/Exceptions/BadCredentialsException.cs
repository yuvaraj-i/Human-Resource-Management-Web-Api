using System.Runtime.Serialization;

namespace HumanResourceManagement.Exceptions
{
    [Serializable]
    internal class BadCredentialsException : Exception
    {
        public BadCredentialsException()
        {
        }

        public BadCredentialsException(string? message) : base(message)
        {
        }

        public BadCredentialsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BadCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}