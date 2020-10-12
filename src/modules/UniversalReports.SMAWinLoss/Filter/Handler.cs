using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class Handler : IRequestHandler<CurrencyHttpParameter, IEnumerable<Currency>>,
        IRequestHandler<SiteHttpParameter, IEnumerable<Site>>,
        IRequestHandler<SportHttpParameter, IEnumerable<Sport>>,
        IRequestHandler<LeagueGroupHttpParameter, IEnumerable<LeagueGroup>>,
        IRequestHandler<AvailableDatabaseHttpParameter, bool>,
        IRequestHandler<AvailableDateDataHttpParameter, string>
    {
        private readonly FilterService service;

        public Handler(FilterService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<LeagueGroup>> Handle(LeagueGroupHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetLeagueGroup();
        }

        public async Task<string> Handle(AvailableDateDataHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetAvailableDateData();
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

        public async Task<bool> Handle(AvailableDatabaseHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetAvailableDatabase();
        }
    }
}