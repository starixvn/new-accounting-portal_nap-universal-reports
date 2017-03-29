using AutoMapper;
using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.League
{
    public class LeagueHandler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<Entity>>
    {
        private readonly IMapper mapper;

        private readonly IDynamicRepository repository;

        public LeagueHandler(IMapper mapper, IDynamicRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<Entity>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<QueryCriteria>(message);
            return await repository.FetchAsync<Entity>(criteria);
        }
    }
}
