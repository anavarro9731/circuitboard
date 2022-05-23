using System;
using System.Runtime.Serialization;

namespace CircuitBoard
{
    public class CircuitException : Exception
    {
        protected CircuitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CircuitException(string message) : base(message)
        {
        }

        public CircuitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}