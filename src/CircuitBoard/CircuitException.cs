using System;


namespace CircuitBoard
{
    public sealed class CircuitException : Exception
    {
        
        public CircuitException(string message, Guid? code = null) : base(message)
        {
            Data.Add("Code", code);
        }

        public CircuitException(string message, Exception innerException, Guid? code = null) : base(message, innerException)
        {
            Data.Add("Code", code);
        }
    }
    
}