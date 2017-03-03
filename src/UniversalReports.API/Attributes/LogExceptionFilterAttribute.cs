using System.Web.Http.Filters;

namespace UniversalReports.API.Attributes
{
    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
#if !DEBUG
            var exception = context.Exception;
            var message = $"{exception.Message}"
                + $"\r\nType: {exception.GetType()}"
                + $"\r\nSource: {exception.Source}"
                          + $"\r\nDomain: {context.Request.Headers.Host}"
                          + $"\r\nRequestUri: {context.Request.RequestUri}"
                          + $"\r\nContent: {context.Request.Content.ReadAsStringAsync().Result}"
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
#endif
        }
    }
}
