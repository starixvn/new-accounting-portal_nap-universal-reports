using Fanex.Caching;
using Fanex.Data.Repository;

namespace UniversalReports.Core.BalanceUpServices
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "CommonBalanceUpRangeCacheKey";

        private readonly IDynamicRepository repository;

        public BalanceUpServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public void ClearCache()
        {
            CacheService.Remove(BalanceUpRangeCacheKey);
        }

        public BalanceUpRange Query()
        {
            var balanceUpRange = CacheService.Get<BalanceUpRange>(BalanceUpRangeCacheKey);
            if (balanceUpRange != null)
            {
                return balanceUpRange;
            }

            balanceUpRange = QueryFromSource();
            CacheService.Set(BalanceUpRangeCacheKey, balanceUpRange);

            return balanceUpRange;
        }

        private BalanceUpRange QueryFromSource()
        {
            var criteria = new BalanceUpCriteria();
            return repository.Get<BalanceUpRange>(criteria);
        }
    }
}