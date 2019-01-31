using System;

namespace TodoApp.Application
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string message) : base(message)
        {
            
        }
    }
}