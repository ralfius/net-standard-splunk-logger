using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Splunk;

namespace SplunkLogger.Writer
{
    public class MicrosoftSplunkLogService: ILogService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory _factory;

        public MicrosoftSplunkLogService()
        {
            _factory = new LoggerFactory()
                .AddSplunk(new SplunkConfiguration()
                {
                    ServerUrl = new Uri("http://localhost:8087"),
                    Token = "1cb44352-504b-409d-8e72-815b2a179006",
                    RetriesOnError = 0,
                    MinLevel = LogLevel.Trace
                }, "MyApplicationName", "MyEnvironmentName");
            _logger = _factory.CreateLogger("Auditing");
        }

        public void WriteInformation(string message)
        {
            var userId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var correlationId = Guid.NewGuid();

            _logger.LogInformation("{Message} {UserId} {AccountId} {CorrelationId}", message, userId, accountId, correlationId);
        }

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
