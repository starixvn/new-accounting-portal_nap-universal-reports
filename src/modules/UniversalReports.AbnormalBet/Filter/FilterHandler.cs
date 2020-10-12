using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Filter
{
    public class FilterHandler : IRequestHandler<SiteHttpParameter, IEnumerable<FilterItemModel>>,
         IRequestHandler<SportHttpParameter, IEnumerable<FilterItemModel>>,
         IRequestHandler<BetTypeHttpParameter, IEnumerable<FilterItemModel>>,
         IRequestHandler<ReasonHttpParameter, IEnumerable<FilterItemModel>>,
         IRequestHandler<CurrencyHttpParameter, IEnumerable<FilterItemModel>>,
         IRequestHandler<LeagueHttpParameter, IEnumerable<LeagueModel>>
    {
        private readonly FilterService filterService;

        public FilterHandler(FilterService filterService)
        {
            this.filterService = filterService;
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(CurrencyHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryCurrency();
        }

        public async Task<IEnumerable<LeagueModel>> Handle(LeagueHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryLeague(request.SportId, request.SearchText, request.SearchExactly);
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(ReasonHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryReason();
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(BetTypeHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QueryBetType(request.SportId);
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(SportHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QuerySport();
        }

        public async Task<IEnumerable<FilterItemModel>> Handle(SiteHttpParameter request, CancellationToken cancellationToken)
        {
            return await filterService.QuerySite();
        }
    }
}