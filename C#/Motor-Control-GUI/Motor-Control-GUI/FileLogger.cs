using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Control_GUI
{
    internal class FileLogger : ILogger
    {
        private string _file_name;
        private string _category_name;
        internal FileLogger(string category_name)
        {
            _category_name = category_name;
            _file_name = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SerialHistory.txt");
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = $"{DateTime.Now}: {formatter(state, exception)}{Environment.NewLine}";
            File.AppendAllText(_file_name, message);
        }
    }
    internal class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}