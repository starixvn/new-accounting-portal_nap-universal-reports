#if !DEBUG
using Fanex.Logging;
using System.Data.SqlClient;
#endif
using System;
using System.Web.Http.Filters;

namespace UniversalReports.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
#if !DEBUG
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            var exception = actionExecutedContext.Exception;
            var message = $"{exception.Message}"
                + $"\r\nType: {exception.GetType()}"
                + $"\r\nSource: {exception.Source}"
                          + $"\r\nDomain: {actionExecutedContext.Request.Headers.Host}"
                          + $"\r\nRequestUri: {actionExecutedContext.Request.RequestUri}"
                          + $"\r\nContent: {actionExecutedContext.Request.Content.ReadAsStringAsync().Result}"
                          + $"\r\nTarget Site: {exception.TargetSite}"
                          + $"\r\nStack Trace: {exception.StackTrace}";

            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                message += $"\r\nProcedure: {sqlException.Procedure}"
                           + $"\r\nLine Number: {sqlException.LineNumber}"
                           + $"\r\nServer: {sqlException.Server}";
            }

            LogService.Error(message);

    }
#endif
    }
}
