using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Fanex.Data;
using Fanex.Data.CrossCutting.WrappingException;
using Fanex.Data.OldConnectionStringProvider;
using Fanex.Logging.Extensions.Database;
using Fanex.Logging.Extensions.Web;

namespace UniversalReports.Sites
{
    public static class FanexLogging
    {
        public static void Register()
        {
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