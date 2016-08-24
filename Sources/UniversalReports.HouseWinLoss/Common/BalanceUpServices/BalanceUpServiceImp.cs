using Fanex.Caching;
using Fanex.Repository;

namespace UniversalReports.HouseWinLoss.Common.BalanceUpServices
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "BalanceUpRangeCacheKey";

        private readonly SimpleRepository repository;

        private readonly ICache cacheService = CacheService.CreateInstance(CacheType.MemoryCache);

        public BalanceUpServiceImp(SimpleRepository repository)
        {
            this.repository = repository;
        }

        public void ClearCache()
        {
            cacheService.Remove(BalanceUpRangeCacheKey);
        }

        public BalanceUpRange Query()
        {
            var balanceUpRange = cacheService.Get<BalanceUpRange>(BalanceUpRangeCacheKey);
            if (balanceUpRange != null)
            {
                return balanceUpRange;
            }

            balanceUpRange = QueryFromSource();
            cacheService.Set(BalanceUpRangeCacheKey, balanceUpRange);

            return balanceUpRange;
        }

        private BalanceUpRange QueryFromSource()
        {
            var criteria = new BalanceUpCriteria();
            return repository.Get<BalanceUpRange>(criteria);
        }
    }
}