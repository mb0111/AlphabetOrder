using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetOrder.Exceptions
{
    public class LettersException : ApplicationException
    {
        public string LogMessage { get; }

        public LettersException(string message, string logMessage = "", Exception exception = null) : base(message, exception)
        {
            LogMessage = logMessage;
        }
    }
}
