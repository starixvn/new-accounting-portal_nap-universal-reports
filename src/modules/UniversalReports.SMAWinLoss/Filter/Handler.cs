using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class Handler : IRequestHandler<CurrencyHttpParameter, IEnumerable<Currency>>,
        IRequestHandler<SiteHttpParameter, IEnumerable<Site>>,
        IRequestHandler<SportHttpParameter, IEnumerable<Sport>>,
        IRequestHandler<LeagueGroupHttpParameter, List<LeagueGroup>>,
        IRequestHandler<AvailableDatabaseHttpParameter, bool>,
        IRequestHandler<AvailableDateDataHttpParameter, string>,
        IRequestHandler<BetFromHttpParameter, IEnumerable<BetFrom>>,
        IRequestHandler<PermissionHttpParameter, int>
    {
        private readonly FilterService service;

        private readonly PermissionService permissionService;

        public Handler(FilterService service, PermissionService permissionService)
        {
            this.service = service;
            this.permissionService = permissionService;
        }

        public async Task<List<LeagueGroup>> Handle(LeagueGroupHttpParameter request, CancellationToken cancellationToken)
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

        public async Task<IEnumerable<BetFrom>> Handle(BetFromHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.GetBetFroms();
        }

        public async Task<int> Handle(PermissionHttpParameter request, CancellationToken cancellationToken)
        {
            return await permissionService.GetPermissionProfileId(request.FunctionKey);
        }
    }
}