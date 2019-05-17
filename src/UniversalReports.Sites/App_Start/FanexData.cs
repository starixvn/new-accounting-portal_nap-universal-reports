using Fanex.Data;
using Fanex.Data.CrossCutting.WrappingException;
using Fanex.NAP.Core.Configuration;

namespace UniversalReports.Sites
{
    public static class FanexData
    {
        public static void Register()
        {
            var resourceFolder = NapSettings.Settings.Environment == "LIVE"
               ? "PRO"
               : "TEST";
            DbSettingProviderManager
             .StartNewSession()
             .UseDefaultConnectionStringProvider()
             .Use((settingKey, commandTimeout) => new WrappingExceptionObjectDb(settingKey, commandTimeout))
             .UseDefaultDbSettingProvider($"~/App_Data/{resourceFolder}")
             .Run();
        }
    }
}