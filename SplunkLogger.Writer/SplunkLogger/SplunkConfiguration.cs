using System;
using Microsoft.Extensions.Logging;
using Splunk.Logging;

namespace SplunkLogger.Writer.SplunkLogger
{
    /// <summary>
    /// 
    /// </summary>
    public class SplunkConfiguration
    {
        public Uri ServerUrl { get; set; }
        public string Token { get; set; }
        public int RetriesOnError { get; set; } = 0;
        public LogLevel MinLevel { get; set; } = LogLevel.Information;
        public Action<HttpEventCollectorException> OnError { get; set; }
        public HttpEventCollectorSender.HttpEventCollectorFormatter Formatter { get; set; }
    }
}
