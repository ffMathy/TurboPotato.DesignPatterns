using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        private interface ILogSink
        {
            bool ShouldLog(LogLevel logLevel);
            void Log(LogLevel logLevel, string message);
        }

        private class Logger
        {
            private readonly IEnumerable<ILogSink> logSinks;

            public Logger(
                IEnumerable<ILogSink> logSinks)
            {
                this.logSinks = logSinks;
            }

            public void Log(LogLevel logLevel, string message)
            {
                foreach(var sink in logSinks)
                {
                    if(!sink.ShouldLog(logLevel))
                        continue;

                    sink.Log(logLevel, message);
                }
            }
        }

        private class ConsoleLogSink : ILogSink
        {
            public bool ShouldLog(LogLevel logLevel)
            {
                return logLevel >= LogLevel.Debug;
            }

            public void Log(LogLevel logLevel, string message)
            {
                Console.WriteLine("Writing to console: " + message);
            }
        }

        private class EmailLogSink : ILogSink
        {
            public bool ShouldLog(LogLevel logLevel)
            {
                return logLevel >= LogLevel.Error;
            }

            public void Log(LogLevel logLevel, string message)
            {
                Console.WriteLine("Writing to email: " + message);
            }
        }

        private class FileLogSink : ILogSink
        {
            public bool ShouldLog(LogLevel logLevel)
            {
                return logLevel >= LogLevel.Warning;
            }

            public void Log(LogLevel logLevel, string message)
            {
                Console.WriteLine("Writing to log file: " + message);
            }
        }

        public static void Main(string[] args)
        {
            var logger = new Logger(new ILogSink[] {
                new ConsoleLogSink(),
                new EmailLogSink(),
                new FileLogSink()
            });

            logger.Log(LogLevel.Debug, "This is a debug message.");
            logger.Log(LogLevel.Info, "This is an info message.");
            logger.Log(LogLevel.Warning, "This is a warning message.");
            logger.Log(LogLevel.Error, "This is an error message.");
        }
    }
}
