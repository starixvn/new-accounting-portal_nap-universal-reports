using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalReports.PlayForFun.Core
{
    public interface PlayForFunService
    {
        Task<ReportModelBase<T>> Query<T>(ICriteria criteria) where T : class, new();
    }

    public class PlayForFunServiceImp : PlayForFunService
    {
        private readonly IDynamicRepository repository;

        public PlayForFunServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ReportModelBase<T>> Query<T>(ICriteria criteria) where T : class, new()
        {
            var entities = await repository.FetchAsync<T>(criteria);
            return new ReportModelBase<T>
            {
                Entities = entities.ToList(),
                Total = entities.DynamicSum()
            };
        }
    }
}
