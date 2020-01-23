using System;

namespace MarsRover.Navigate
{
    public class CustomException : Exception
    {
        public CustomException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}

