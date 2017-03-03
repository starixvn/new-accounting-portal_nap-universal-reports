using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public static class FanexDataConfiguration
    {
        private static bool initialized = false;

        public static void Initialize()
        {
            if (initialized)
            {
                return;
            }

            DbSettingProviderManager
           .StartNewSession()
           .Use(new OldConnectionStringProvider())
           .UseDefaultDbSettingProvider(
             resourcePath: $"~/App_Data/LOCAL",
             ignoreRedundantParameters: false,
             enableWatching: true)
           .Run();
        }
    }
}