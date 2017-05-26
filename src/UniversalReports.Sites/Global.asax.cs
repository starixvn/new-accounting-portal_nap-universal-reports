using Fanex.Data.CrossCutting.WrappingException;
using Fanex.Logging;
using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace UniversalReports.Sites
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ChangeApplicationName();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FanexData.Register();
        }

        private static void ChangeApplicationName()
        {
            const string ApplicationName = "NAP_ACC_REPORT";

            // Change the Application Name in runtime.
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
            var theRuntime = runtimeInfo.GetValue(null);

            appNameInfo.SetValue(theRuntime, ApplicationName);
        }

        protected void Application_PostAuthorizeRequest()
        {
            var request = HttpContext.Current.Request;
            if (request.Url.ToString().Contains("api/application/header")
                || request.Url.ToString().Contains("api/punter-analysis/filter/username-suggestion"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError().GetBaseException();

            if (exception is HttpException)
            {
                return;
            }

            var messageBuilder = new StringBuilder();
            messageBuilder.Append($"{exception.Message}");
            messageBuilder.Append($"\r\nType: {exception.GetType()}");
            messageBuilder.Append($"\r\nSource: {exception.Source}");
            messageBuilder.Append($"\r\nDomain: {HttpContext.Current.Request.Headers["Host"]}");
            messageBuilder.Append($"\r\nQuery String: {Request.QueryString}");
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
    }
}