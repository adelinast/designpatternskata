using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsibility
{
    class FileLogger : Logger
    {
        public FileLogger(LogLevel level)
            : base(level)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to Log File: " + msg);
        }
    }
}