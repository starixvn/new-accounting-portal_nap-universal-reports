using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;

namespace UniversalReports.DatabaseTestSetup
{
    public static class FanexDataSetup
    {
        private static bool intialized;

        public static void Setup()
        {
            if (intialized)
            {
                return;
            }

            intialized = true;
            DbSettingProviderManager
              .StartNewSession()
              .Use(new OldConnectionStringProvider())
              .UseDefaultDbSettingProvider("~/App_Data/LOCAL", false, true)
              .Run();
        }
    }
}
