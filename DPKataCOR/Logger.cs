using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public abstract class Logger
    {
        protected LogLevel logLevel;

        // The next Handler in the chain
        protected Logger next;

        public Logger(LogLevel level)
        {
            logLevel = level;
        }

        public Logger SetNext(Logger nextLogger)
        {
            next = nextLogger;
            return nextLogger;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & logLevel) != 0)
            {
                WriteMessage(msg);
            }

            if (next != null)
            {
                next.Message(msg, severity);
            }
        }

        abstract protected void WriteMessage(string msg);
    }

}