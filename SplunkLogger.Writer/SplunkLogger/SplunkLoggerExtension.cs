using System;
using Microsoft.Extensions.Logging;

namespace SplunkLogger.Writer.SplunkLogger
{
    public static class SplunkLoggerExtension
    {
        public static ILoggerFactory AddSplunk(this ILoggerFactory factory, global::SplunkLogger.Writer.SplunkLogger.SplunkConfiguration configuration, string applicationName, string environmentName)
        {
            if (string.IsNullOrEmpty(applicationName))
            {
                throw new ArgumentNullException(nameof(applicationName));
            }

            if (string.IsNullOrEmpty(environmentName))
            {
                throw new ArgumentNullException(nameof(environmentName));
            }

            ILoggerProvider provider = new global::SplunkLogger.Writer.SplunkLogger.SplunkLoggerProvider((n, l, e) => l >= configuration.MinLevel, configuration);

            factory.AddProvider(provider);

            return factory;
        }
    }
}
