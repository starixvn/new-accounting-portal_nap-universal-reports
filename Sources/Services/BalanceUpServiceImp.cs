using Fanex.Caching;
using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "BalanceUpRangeCacheKey";

        private IDynamicRepository _repository;

        private ICache _cacheService = CacheService.CreateInstance(CacheType.MemoryCache);

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
            if (balanceUpRange == null)
            {
                balanceUpRange = QueryFromSource();
                _cacheService.Set(BalanceUpRangeCacheKey, balanceUpRange);
            }

            return balanceUpRange;
        }

        private BalanceUpRange QueryFromSource()
        {
            var criteria = new BalanceUpCriteria();
            return _repository.Get<BalanceUpRange>(criteria);
        }
    }
}
