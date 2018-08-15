using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    public class Handler : IRequestHandler<HttpParameterJson, SummaryEntity<ExchangeEntity>>
    {
        private readonly Service service;

        public Handler(Service service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<ExchangeEntity>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {

            return await service.Query(request).ConfigureAwait(false);
        }
    }
}