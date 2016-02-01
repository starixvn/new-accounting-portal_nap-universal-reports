using Fanex.Data.Configuration;
using System.Web.Http;

namespace UniversalReports.Sites
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DbSettingProviderManager.Current.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SimpleInjectorConfig.Register();
        }
    }
}