using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.MarginBySite
{
    public class MarginBySiteHandler : IRequestHandler<MarginBySiteHttpParameter, SummaryEntity<MarginBySiteItemModel>>
    {
        private readonly MarginBySiteService service;

        public MarginBySiteHandler(MarginBySiteService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<MarginBySiteItemModel>> Handle(MarginBySiteHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}