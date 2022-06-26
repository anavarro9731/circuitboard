using System;

namespace CircuitBoard
{
    public sealed class CircuitException : Exception
    {
        public CircuitException(ErrorCode error) : base(error.Value)
        {
            error.Active = true;
            Error = error;
        }
        
        public CircuitException(string appendedMessage, ErrorCode error) : base(error.Value)
        {
            error.Active = true;
            error.Value += " " + appendedMessage;
            Error = error;
        }

        public CircuitException(string message) : base(message)
        {
        }

        public CircuitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ErrorCode Error { get; set; }
    }
}