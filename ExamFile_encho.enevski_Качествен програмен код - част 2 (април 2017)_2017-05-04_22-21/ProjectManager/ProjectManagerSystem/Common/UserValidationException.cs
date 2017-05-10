using System;

namespace ProjectManagerSystem.Common.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string msg)
            : base(" - Error: " + msg)
        {
        }
    }
}