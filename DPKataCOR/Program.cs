namespace ChainOfResponsibility
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build the chain of responsibility
            Logger Logger, LoggerFunc, LoggerWarnErr;
            Logger = new ConsoleLogger(LogLevel.ALL);
            LoggerFunc = Logger.SetNext(new EmailLogger(LogLevel.FUNCTIONAL_ERR | LogLevel.FUNCTIONAL_MSG));
            LoggerWarnErr = LoggerFunc.SetNext(new FileLogger(LogLevel.WARN | LogLevel.ERR));

            // Handled by ConsoleLogger since the console has a loglevel of all
            Logger.Message("Entering function", LogLevel.DBG);
            Logger.Message("Data retrieved", LogLevel.INFO);

            // Handled by ConsoleLogger and FileLogger - Warning & Error
            Logger.Message("Warning empty field", LogLevel.WARN);
            Logger.Message("Error getting data", LogLevel.ERR);

            // Handled by ConsoleLogger and EmailLogger - functional error
            Logger.Message("Error calculating events", LogLevel.FUNCTIONAL_ERR);

            // Handled by ConsoleLogger and EmailLogger
            Logger.Message("Date is not valid", LogLevel.FUNCTIONAL_MSG);
        }
    }
}
