using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class Handler : IRequestHandler<CurrencyHttpParameter, IEnumerable<Currency>>,
        IRequestHandler<SiteHttpParameter, IEnumerable<Site>>,
        IRequestHandler<SportHttpParameter, IEnumerable<Sport>>,
        IRequestHandler<LeagueGroupHttpParameter, IEnumerable<string>>
    {
        private readonly FilterService service;

        public Handler(FilterService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<string>> Handle(LeagueGroupHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetLeagueGroupBySport(request);
        }

        public async Task<IEnumerable<Sport>> Handle(SportHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetSports();
        }

        public async Task<IEnumerable<Site>> Handle(SiteHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetSites();
        }

        public async Task<IEnumerable<Currency>> Handle(CurrencyHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetCurrencies();
        }
    }
}