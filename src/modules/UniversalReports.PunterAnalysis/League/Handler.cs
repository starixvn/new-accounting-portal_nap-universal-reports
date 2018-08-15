using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class Handler : IRequestHandler<HttpParameterJson, ReportModel>
    {
        private readonly LeagueServiceFactory leagueServiceFactory;

        public Handler(LeagueServiceFactory leagueServiceFactory)
        {
            this.leagueServiceFactory = leagueServiceFactory;
        }

        public async Task<ReportModel> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);

            var leagueService = leagueServiceFactory.CreateLeagueService(request.PeriodType);
            return await leagueService.Query(criteria).ConfigureAwait(false);
        }
    }
}