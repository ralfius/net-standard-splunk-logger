using System;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Splunk;

namespace SplunkLogger.Writer
{
    public class SerilogLogService : ILogService, IDisposable
    {
        private readonly Logger _logger;

        public SerilogLogService()
        {
            //TODO test with real splunk
            _logger = new LoggerConfiguration()
                .AuditTo.Sink(new EventCollectorSink(
                    "http://localhost:8088/services/collector2",
                    "1cb44352-504b-409d-8e72-815b2a179006",
                    "path",
                    1,
                    1,
                    new CompactSplunkJsonFormatter()))
                //.WriteTo.Async(a => a.EventCollector(
                //    "http://localhost:8088/services/collector",
                //    "1cb44352-504b-409d-8e72-815b2a179006",
                //    new CompactSplunkJsonFormatter()))
                .Enrich.WithMachineName()
                .CreateLogger();
        }

        //TODO consider it as non-blocking async operation
        public void WriteInformation(string message)
        {
            var userId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var correlationId = Guid.NewGuid();

            //TODO send logs to another place if splunk is not available
            _logger.Information("{Message} {UserId} {AccountId} {CorrelationId}", message, userId, accountId, correlationId);
        }

        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}
