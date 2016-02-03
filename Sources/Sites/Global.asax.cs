using Fanex.Data.Configuration;
using System.Web.Http;
using System.Web.Optimization;

namespace UniversalReports.Sites
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DbSettingProviderManager.Current.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorConfig.Register();
        }
    }
}