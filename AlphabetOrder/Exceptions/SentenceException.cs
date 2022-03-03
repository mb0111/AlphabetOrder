using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetOrder.Exceptions
{
    public class SentenceException : ApplicationException
    {
        public string LogMessage { get; }

        public SentenceException(string message, string logMessage = "", Exception exception = null) : base(message, exception)
        {
            LogMessage = logMessage;
        }
    }
}
