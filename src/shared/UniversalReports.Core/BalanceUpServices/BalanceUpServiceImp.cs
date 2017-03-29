using Fanex.Caching;
using Fanex.Data.Repository;

namespace UniversalReports.Core.BalanceUpServices
{
    public class BalanceUpServiceImp : BalanceUpService
    {
        private const string BalanceUpRangeCacheKey = "CommonBalanceUpRangeCacheKey";

        private readonly IDynamicRepository repository;

        private readonly CacheService cacheService;

        public BalanceUpServiceImp(IDynamicRepository repository, CacheService cacheService)
        {
            this.repository = repository;
            this.cacheService = cacheService;
        }

        public BalanceUpRange Query()
        {
            return cacheService.GetOrSet(
                BalanceUpRangeCacheKey,
                QueryFromSource);
        }

        public BalanceUpRange QueryFromSource()
        {
            var criteria = new BalanceUpCriteria();
            return repository.Get<BalanceUpRange>(criteria);
        }
    }
}