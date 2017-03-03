using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface PunterAnalysisService
    {
        Task<ModelBase<T>> Query<T>(ICriteria criteria) where T : class, new();

        ModelBase<T> Transform<T>(IEnumerable<T> items) where T : class, new();
    }

    public class PunterAnalysisServiceImp : PunterAnalysisService
    {
        private readonly IDynamicRepository repository;

        public PunterAnalysisServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ModelBase<T>> Query<T>(ICriteria criteria) where T : class, new()
        {
            var entities = await repository.FetchAsync<T>(criteria);
            return Transform(entities);
        }

        public ModelBase<T> Transform<T>(IEnumerable<T> entities) where T : class, new()
        {
            return new ModelBase<T>
            {
                Entities = entities.ToList(),
                Total = entities.DynamicSum()
            };
        }
    }
}
