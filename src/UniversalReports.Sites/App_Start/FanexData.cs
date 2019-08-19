using Fanex.Data;
using Fanex.Data.SqlServer;

namespace UniversalReports.Sites
{
    public static class FanexData
    {
        public static void Register()
        {
            DbSettingProviderManager
             .StartNewSession()
             .WithSqlServer($"~/App_Data")
             .Run();
        }
    }
}