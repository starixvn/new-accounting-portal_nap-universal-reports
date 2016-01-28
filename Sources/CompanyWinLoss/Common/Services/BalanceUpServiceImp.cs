using Fanex.Caching;
using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "BalanceUpRangeCacheKey";

        private readonly IDynamicRepository _repository;

        private readonly ICache _cacheService = CacheService.CreateInstance(CacheType.MemoryCache);

        public BalanceUpServiceImp(IDynamicRepository repository)
        {
            _repository = repository;
        }

        public void ClearCache()
        {
            _cacheService.Remove(BalanceUpRangeCacheKey);
        }

        public BalanceUpRange Query()
        {
            var balanceUpRange = _cacheService.Get<BalanceUpRange>(BalanceUpRangeCacheKey);
            if (balanceUpRange != null)
            {
                return balanceUpRange;
            }

            balanceUpRange = QueryFromSource();
            _cacheService.Set(BalanceUpRangeCacheKey, balanceUpRange);

            return balanceUpRange;
        }

        private BalanceUpRange QueryFromSource()
        {
            var criteria = new BalanceUpCriteria();
            return _repository.Get<BalanceUpRange>(criteria);
        }
    }
}
