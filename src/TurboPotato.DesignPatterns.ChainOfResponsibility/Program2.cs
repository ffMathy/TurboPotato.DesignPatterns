using System;

namespace TurboPotato.DesignPatterns.ChainOfResponsibility
{
    public class Program2
    {
        private enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }

        private abstract class Logger
        {
            protected LogLevel minimumLogLevel;

            protected Logger next;

            public Logger(LogLevel mask)
            {
                this.minimumLogLevel = mask;
            }

            public Logger SetNext(Logger nextLogger)
            {
                Logger lastLogger = this;

                while (lastLogger.next != null)
                {
                    lastLogger = lastLogger.next;
                }

                lastLogger.next = nextLogger;
                return this;
            }

            public void Message(string message, LogLevel logLevel)
            {
                if (logLevel >= minimumLogLevel)
                    WriteMessage(logLevel + ": " + message);

                next?.Message(message, logLevel);
            }

            abstract protected void WriteMessage(string msg);
        }

        private class ConsoleLogger : Logger
        {
            public ConsoleLogger(LogLevel minimumLogLevel)
                : base(minimumLogLevel)
            { }

            protected override void WriteMessage(string msg)
            {
                Console.WriteLine("Writing to console: " + msg);
            }
        }

        private class EmailLogger : Logger
        {
            public EmailLogger(LogLevel minimumLogLevel)
                : base(minimumLogLevel)
            { }

            protected override void WriteMessage(string msg)
            {
                Console.WriteLine("Writing to email: " + msg);
            }
        }

        private class FileLogger : Logger
        {
            public FileLogger(LogLevel minimumLogLevel)
                : base(minimumLogLevel)
            { }

            protected override void WriteMessage(string msg)
            {
                Console.WriteLine("Writing to log file: " + msg);
            }
        }

        public static void Main(string[] args)
        {
            var logger = new ConsoleLogger(LogLevel.Debug)
                .SetNext(new EmailLogger(LogLevel.Info))
                .SetNext(new FileLogger(LogLevel.Warning));

            logger.Message("This is a debug message.", LogLevel.Debug);
            logger.Message("This is an info message.", LogLevel.Info);
            logger.Message("This is a warning message.", LogLevel.Warning);
            logger.Message("This is an error message.", LogLevel.Error);

        }
    }
}
