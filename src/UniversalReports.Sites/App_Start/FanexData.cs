using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using System.Configuration;

namespace UniversalReports.Sites
{
    public static class FanexData
    {
        public static void Register()
        {
            var environment = ConfigurationManager.AppSettings["Environment"];
            DbSettingProviderManager
             .StartNewSession()
             .Use(new OldConnectionStringProvider())
             .UseDefaultDbSettingProvider($"~/App_Data/{environment}", enableWatching: true).Run();
        }
    }
}