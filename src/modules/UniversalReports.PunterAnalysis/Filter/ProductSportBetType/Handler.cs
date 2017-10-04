using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.ProductSportBetType
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<ProductSportBetTypeEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProductSportBetTypeEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<ProductSportBetTypeEntity>(criteria).ConfigureAwait(false);
        }
    }
}