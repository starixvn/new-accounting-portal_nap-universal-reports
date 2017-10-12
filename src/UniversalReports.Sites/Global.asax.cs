using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using AutoMapper;
using Fanex.Data.CrossCutting.WrappingException;
using Fanex.Logging;

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
            FanexLogging.Register();
            Mapper.Initialize(cfg => cfg.CreateMissingTypeMaps = true);
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
                || request.Url.ToString().Contains("api/punter-analysis/filter/username-suggestion")
                || request.Url.ToString().Contains("state-api/application/header"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            FanexLogging.HandleApplicationError(Server);
        }
    }
}