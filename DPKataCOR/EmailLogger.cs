using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    public class EmailLogger : Logger
    {
        public EmailLogger(LogLevel level)
            : base(level)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Sending via email: " + msg);
        }
    }
}