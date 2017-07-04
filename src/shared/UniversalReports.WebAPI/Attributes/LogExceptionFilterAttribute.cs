#if !DEBUG
using Fanex.Data.CrossCutting.WrappingException;
using Fanex.Logging;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

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
            var messageBuilder = new StringBuilder();
            messageBuilder.Append($"{exception.Message}");
            messageBuilder.Append($"\r\nType: {exception.GetType()}");
            messageBuilder.Append($"\r\nSource: {exception.Source}");
            messageBuilder.Append($"\r\nUrl: {actionExecutedContext.Request.RequestUri}");
            messageBuilder.Append($"\r\nDomain: {actionExecutedContext.Request.Headers.Host}");
            messageBuilder.Append($"\r\nQuery String: {actionExecutedContext.Request.RequestUri.Query}");
            messageBuilder.Append($"\r\nFormContent: {actionExecutedContext.Request.Content.ReadAsStringAsync().Result}");
            messageBuilder.Append($"\r\nTarget Site: {exception.TargetSite}");
            messageBuilder.Append($"\r\nStack Trace: {exception.StackTrace}");

            var objectDbException = exception as ObjectDbException;
            if (objectDbException != null)
            {
                messageBuilder.Append($"\r\nSettingKey: {objectDbException.SettingKey}");
                foreach (DbParameter parameter in objectDbException.Parameters)
                {
                    messageBuilder.Append($"\r\nParamName: {parameter.ParameterName}. Value: {parameter.Value}");
                }
            }

            LogService.Error(messageBuilder.ToString());
        }
#endif
    }
}
