using System;

namespace TodoApp.Domain
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
            
        }
    }
}