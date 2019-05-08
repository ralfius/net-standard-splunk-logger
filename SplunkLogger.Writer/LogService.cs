using System;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Splunk;

namespace SplunkLogger.Writer
{
    public class LogService : ILogService, IDisposable
    {
        private readonly Logger _logger;

        public LogService()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.EventCollector(
                    "http://localhost:8088/services/collector",
                    "1cb44352-504b-409d-8e72-815b2a179006",
                    new CompactSplunkJsonFormatter(true))
                .CreateLogger();
        }

        public void WriteInformation(string message)
        {
            _logger.Information(message);
        }

        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}
