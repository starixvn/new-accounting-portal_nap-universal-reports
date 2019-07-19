using Fanex.Data;
using Fanex.Data.SqlServer;
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
             .WithSqlServer($"~/App_Data/{resourceFolder}")
             .Run();
        }
    }
}