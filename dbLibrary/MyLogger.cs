using System;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace dbLibrary
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose() { }

        private class MyLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public async void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                
               //await File.AppendAllTextAsync("C:\\Users\\goha7\\Desktop\\prog\\timp\\5 sem timp\\repos\\bma\\bmaForm\\bin\\Debug\\net7.0-windows\\dataFiles\\log.txt", "\n" + formatter(state, exception));
                
            }
        }
    }
}