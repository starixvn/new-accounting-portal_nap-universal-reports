using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.MarginBySite
{
    public class SiteHandler : IRequestHandler<SiteHttpParameter, SummaryEntity<SiteItemModel>>
    {
        private readonly SiteService service;

        public SiteHandler(SiteService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<SiteItemModel>> Handle(SiteHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}