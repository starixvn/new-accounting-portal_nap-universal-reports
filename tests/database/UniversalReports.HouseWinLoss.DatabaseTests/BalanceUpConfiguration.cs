using Fanex.Caching;
using Fanex.Data.Repository;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.HouseWinLoss.DatabaseTests
{
    public class BalanceUpConfiguration
    {
        private static BalanceUpRange balanceUpRange;

        public static BalanceUpRange BalanceUpRange
        {
            get
            {
                if (balanceUpRange == null)
                {
                    var repository = new DynamicRepository();
                    var cacheService = new CacheServiceImpl();
                    var balanceUpService = new BalanceUpServiceImp(repository, cacheService);
                    balanceUpRange = balanceUpService.Query();
                }

                return balanceUpRange;
            }
        }
    }
}
