using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.SportTypeLeague
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<SportTypeLeagueEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SportTypeLeagueEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria { SportId = message.SportId };
            return await repository.FetchAsync<SportTypeLeagueEntity>(criteria);
        }
    }
}
