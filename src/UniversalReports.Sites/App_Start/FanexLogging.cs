using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Fanex.Logging;
using Fanex.Logging.Extensions;
using Fanex.Logging.Extensions.Database;
using Fanex.Logging.Extensions.Web;
using Fanex.Logging.RabbitMQ;
using Fanex.Logging.Sentry.RavenClient;
using SharpRaven;

namespace UniversalReports.Sites
{
    public static class FanexLogging
    {
        public static void Register()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var sentryToken = appSettings["SentryToken"];
            var frontEndSentryToken = appSettings["FrontEndSentryToken"];
            var logCategory = appSettings["SiteCategory"];
            var rabbitMQ = appSettings["RabbitMQConnectionString"];
            var logEngines = new List<ILogEngine>();
            if (!string.IsNullOrEmpty(sentryToken) && !string.IsNullOrEmpty(frontEndSentryToken))
            {
                var sentryEngineOptions = new SentryEngineOptions
                {
                    Dsn = new Dsn(sentryToken),
                    FrontEndDsn = new Dsn(frontEndSentryToken),
                };
                var sentryEngine = new SentryLogging(sentryEngineOptions);
                logEngines.Add(sentryEngine);
            }

            if (!string.IsNullOrEmpty(rabbitMQ))
            {
                var rabbitMQEngine = new RabbitMQLogging(rabbitMQ);
                logEngines.Add(rabbitMQEngine);
            }


            LogManager
           .SetDefaultLogCategory(logCategory)
           .Use(logEngines);

            var configuration = new LoggingConfiguration()
                 .GetHttpHeaderInfo()
                 .GetHttpSessionInfo()
                 .UseGetDbExceptionInfo(DatabaseInfoGetters.GetDbExceptionInfo);
            ExceptionHandler.UseConfig(configuration);
        }

        public static void HandleApplicationError(HttpServerUtility server)
        {
            ExceptionHandler.Handle(server.GetLastError());
        }
    }
}