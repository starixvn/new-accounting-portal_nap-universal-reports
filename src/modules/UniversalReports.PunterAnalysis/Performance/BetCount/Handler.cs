using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Performance.BetCount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<BetCountModel>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BetCountModel>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<BetCountModel>(criteria);
        }
    }
}
