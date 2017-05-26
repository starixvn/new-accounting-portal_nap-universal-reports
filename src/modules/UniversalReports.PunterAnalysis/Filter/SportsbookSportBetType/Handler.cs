using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<SportsbookSportBetTypeEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SportsbookSportBetTypeEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<SportsbookSportBetTypeEntity>(criteria).ConfigureAwait(false);
        }
    }
}
