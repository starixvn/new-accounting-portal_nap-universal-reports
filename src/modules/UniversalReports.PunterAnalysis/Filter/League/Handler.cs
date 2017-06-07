using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.League
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<LeagueEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LeagueEntity>> Handle(HttpParameterJson message)
        {
            var criteria = Mapper.Map<QueryCriteria>(message);
            return await repository.FetchAsync<LeagueEntity>(criteria).ConfigureAwait(false);
        }
    }
}
