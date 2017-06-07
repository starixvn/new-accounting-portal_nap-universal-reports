using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;

namespace UniversalReports.PlayForFun.Core
{
    public interface PlayForFunService
    {
        Task<SummaryEntity<T>> Query<T>(ICriteria criteria) where T : class, new();
    }

    public class PlayForFunServiceImp : PlayForFunService
    {
        private readonly IDynamicRepository repository;

        public PlayForFunServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<T>> Query<T>(ICriteria criteria) where T : class, new()
        {
            return (await repository.FetchAsync<T>(criteria).ConfigureAwait(false))
                    .CalculateSummaryEntity();
        }
    }
}
