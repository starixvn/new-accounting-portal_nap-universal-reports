using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.League
{
    public class Handler : IRequestHandler<HttpParameterJson, IEnumerable<LeagueEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LeagueEntity>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<QueryCriteria>(request);
            return await repository.FetchAsync<LeagueEntity>(criteria).ConfigureAwait(false);
        }
    }
}