using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.Sport
{
    public class SportHandler : IRequestHandler<SportHttpParameter, SummaryEntity<SportItemModel>>
    {
        private readonly SportService service;

        public SportHandler(SportService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<SportItemModel>> Handle(SportHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}