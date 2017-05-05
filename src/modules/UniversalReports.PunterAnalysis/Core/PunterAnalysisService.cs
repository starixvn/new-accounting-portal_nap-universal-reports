using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface PunterAnalysisService
    {
        Task<ReportModelBase<T>> Query<T>(ICriteria criteria) where T : class, new();
    }

    public class PunterAnalysisServiceImp : PunterAnalysisService
    {
        private readonly IDynamicRepository repository;

        public PunterAnalysisServiceImp(IDynamicRepository repository)
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
