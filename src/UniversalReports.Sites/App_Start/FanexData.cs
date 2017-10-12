using System.Configuration;
using Fanex.Data;
using Fanex.Data.CrossCutting.WrappingException;
using Fanex.Data.OldConnectionStringProvider;

namespace UniversalReports.Sites
{
    public static class FanexData
    {
        public static void Register()
        {
            var environment = ConfigurationManager.AppSettings["Environment"];
            var resourceFolder = environment == "PRO" || environment == "MNL" || environment == "MASTER"
               ? "LIVE"
               : "TEST";
            DbSettingProviderManager
             .StartNewSession()
             .Use(new OldConnectionStringProvider())
             .Use((settingKey, commandTimeout) => new WrappingExceptionObjectDb(settingKey, commandTimeout))
             .UseDefaultDbSettingProvider($"~/App_Data/{resourceFolder}", enableWatching: true).Run();
        }
    }
}