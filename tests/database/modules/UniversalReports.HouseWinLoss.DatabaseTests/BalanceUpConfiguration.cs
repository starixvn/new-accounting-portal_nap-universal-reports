using Fanex.Caching;
using Fanex.Data.Repository;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.DatabaseTestSetup;

namespace UniversalReports.HouseWinLoss.DatabaseTests
{
    public static class BalanceUpConfiguration
    {
        static BalanceUpConfiguration()
        {
            FanexDataSetup.Setup();
        }

        private static BalanceUpRange balanceUpRange;

        public static BalanceUpRange BalanceUpRange
        {
            get
            {
                if (balanceUpRange != null)
                {
                    return balanceUpRange;
                }

                var repository = new DynamicRepository();
                var cacheService = new CacheServiceImpl();
                var balanceUpService = new BalanceUpServiceImp(repository, cacheService);
                balanceUpRange = balanceUpService.Query();

                return balanceUpRange;
            }
        }
    }
}