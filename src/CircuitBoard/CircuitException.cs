using System;


namespace CircuitBoard
{
    public class CircuitException : Exception
    {
        
        public CircuitException(string message) : base(message)
        {
        }

        public CircuitException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}