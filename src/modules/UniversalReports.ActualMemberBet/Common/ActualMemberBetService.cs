using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;

namespace UniversalReports.ActualMemberBet.Common
{
    public interface ActualMemberBetService
    {
        Task<SummaryEntity<T>> Query<T>(ICriteria criteria) where T : class, new();
    }

    public class ActualMemberBetServiceImp : ActualMemberBetService
    {
        private readonly IDynamicRepository repository;

        public ActualMemberBetServiceImp(IDynamicRepository repository)
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
