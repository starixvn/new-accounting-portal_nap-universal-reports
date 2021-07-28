using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.League
{
    public class LeagueHandler : IRequestHandler<LeagueHttpParameter, SummaryEntity<LeagueItemModel>>
    {
        private readonly LeagueService service;

        public LeagueHandler(LeagueService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<LeagueItemModel>> Handle(LeagueHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}