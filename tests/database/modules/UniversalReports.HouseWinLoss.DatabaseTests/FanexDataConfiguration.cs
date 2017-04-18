using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;

namespace UniversalReports.HouseWinLoss.DatabaseTests
{
    public static class FanexDataConfiguration
    {
        private static bool initialized;

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
             "~/App_Data/LOCAL",
             false,
             true)
           .Run();

            initialized = true;
        }
    }
}