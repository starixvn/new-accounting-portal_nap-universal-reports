using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.LeagueGroup
{
    public class Handler : IRequestHandler<HttpParameterJson, IEnumerable<LeagueGroupEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LeagueGroupEntity>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<LeagueGroupEntity>(criteria);
        }
    }
}