using System;

namespace CircuitBoard
{
    public sealed class CircuitException : Exception
    {
        public CircuitException(string message, ErrorCode error = null) : base(message)
        {
            Error = error;
        }

        public CircuitException(string message, Exception innerException, ErrorCode error = null) : base(message,
            innerException)
        {
            Error = error;
        }
        
        public ErrorCode Error { get; set; }
    }
}