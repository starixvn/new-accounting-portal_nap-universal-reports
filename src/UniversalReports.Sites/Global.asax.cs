using Fanex.Logging;
using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
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

        protected void Application_PostAuthorizeRequest()
        {
            var request = HttpContext.Current.Request;
            if (request.Url.ToString().Contains("api/application/header"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private void ChangeApplicationName()
        {
            const string ApplicationName = "NAP_ACC_REPORT";

            // Change the Application Name in runtime.
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
            var theRuntime = runtimeInfo.GetValue(null);

            appNameInfo.SetValue(theRuntime, ApplicationName);
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
            "SP2101:MethodMustNotContainMoreLinesThan",
            Justification = "Reviewed. Suppression is OK here.")]
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError().GetBaseException();

            if (exception is HttpException)
            {
                return;
            }

            var message = $"{exception.Message}"
                + $"\r\nType: {exception.GetType()}"
                + $"\r\nSource: {exception.Source}"
                          + $"\r\nDomain: {HttpContext.Current.Request.Headers["Host"]}"
                          + $"\r\nQuery String: {Request.QueryString}"
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
    }
}