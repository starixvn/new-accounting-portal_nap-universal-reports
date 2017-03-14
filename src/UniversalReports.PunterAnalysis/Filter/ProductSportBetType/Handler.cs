using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.ProductSportBetType;

namespace UniversalReports.PunterAnalysis.Filter
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<Entity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Entity>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<Entity>(criteria);
        }


    }
}
