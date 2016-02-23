using Fanex.Data.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace UniversalReports.Sites
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CheatApplicationName();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DbSettingProviderManager.Current.Start();
            SimpleInjectorConfig.Register();
        }

        protected void Application_PostAuthorizeRequest()
        {
            var request = HttpContext.Current.Request;
            if (request.Url.ToString().Contains("api/application/menu"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }
        
        private void CheatApplicationName()
        {
            string applicationName = "NAP_ACC_REPORT";

            // Change the Application Name in runtime.
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            var theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);

            appNameInfo.SetValue(theRuntime, applicationName);
        }
    }
}