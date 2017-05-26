using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface PunterAnalysisService
    {
        Task<SummaryEntity<T>> Query<T>(ICriteria criteria) where T : class, new();
    }

    public class PunterAnalysisServiceImp : PunterAnalysisService
    {
        private readonly IDynamicRepository repository;

        public PunterAnalysisServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<T>> Query<T>(ICriteria criteria) where T : class, new()
        {
            var entities = await repository.FetchAsync<T>(criteria).ConfigureAwait(false);
            return entities.CalculateSummaryEntity();
        }
    }
}
