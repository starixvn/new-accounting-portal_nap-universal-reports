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
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorConfig.Register();
        }
    }
}