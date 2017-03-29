using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ViewModelJson>
    {
        private readonly IMapper mapper;

        private readonly LeagueServiceFactory leagueServiceFactory;

        public Handler(IMapper mapper, LeagueServiceFactory leagueServiceFactory)
        {
            this.mapper = mapper;
            this.leagueServiceFactory = leagueServiceFactory;
        }

        public async Task<ViewModelJson> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);

            var leagueService = leagueServiceFactory.CreateLeagueService(message.PeriodType);
            var model = await leagueService.Query(criteria);
            var viewModel = mapper.Map<ViewModelJson>(model);

            return viewModel;
        }
    }
}
