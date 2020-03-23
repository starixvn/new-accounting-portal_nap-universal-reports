using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Filter
{
    public class FilterHandler : IRequestHandler<SiteHttpParameter, IEnumerable<SiteModel>>,
         IRequestHandler<SportHttpParameter, IEnumerable<SportModel>>,
         IRequestHandler<BetTypeHttpParameter, IEnumerable<BetTypeModel>>,
         IRequestHandler<ReasonHttpParameter, IEnumerable<ReasonModel>>
    {
        private readonly FilterService filterService;

        public FilterHandler(FilterService filterService)
        {
            this.filterService = filterService;
        }

        public async Task<IEnumerable<ReasonModel>> Handle(ReasonHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryReason();
        }

        public async Task<IEnumerable<BetTypeModel>> Handle(BetTypeHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryBetType(request.SportId);
        }

        public async Task<IEnumerable<SportModel>> Handle(SportHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QuerySport();
        }

        public async Task<IEnumerable<SiteModel>> Handle(SiteHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QuerySite();
        }
    }
}
