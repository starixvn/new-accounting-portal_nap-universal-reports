using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ReportModel>
    {
        private readonly LeagueServiceFactory leagueServiceFactory;

        public Handler(LeagueServiceFactory leagueServiceFactory)
        {
            this.leagueServiceFactory = leagueServiceFactory;
        }

        public async Task<ReportModel> Handle(HttpParameterJson message)
        {
            var criteria = Mapper.Map<Criteria>(message);

            var leagueService = leagueServiceFactory.CreateLeagueService(message.PeriodType);
            return await leagueService.Query(criteria).ConfigureAwait(false);
        }
    }
}
