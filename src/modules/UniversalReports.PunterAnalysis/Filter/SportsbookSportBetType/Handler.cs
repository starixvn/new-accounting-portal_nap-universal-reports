using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType
{
    public class Handler : IRequestHandler<HttpParameterJson, IEnumerable<SportsbookSportBetTypeEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SportsbookSportBetTypeEntity>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<SportsbookSportBetTypeEntity>(criteria).ConfigureAwait(false);
        }
    }
}