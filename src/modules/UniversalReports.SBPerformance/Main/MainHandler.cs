using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.Main
{
    public class MainHandler : IRequestHandler<HttpParameter, SummaryEntity<ItemModel>>
    {
        private readonly MainService service;

        public MainHandler(MainService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<ItemModel>> Handle(HttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}