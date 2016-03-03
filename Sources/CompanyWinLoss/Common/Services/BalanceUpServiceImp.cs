using Fanex.Caching;
using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "BalanceUpRangeCacheKey";

        private readonly IDynamicRepository repository;

        private readonly ICache cacheService = CacheService.CreateInstance(CacheType.MemoryCache);

        public BalanceUpServiceImp(IDynamicRepository repository)
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