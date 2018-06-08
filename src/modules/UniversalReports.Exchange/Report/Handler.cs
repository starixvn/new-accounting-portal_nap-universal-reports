using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, SummaryEntity<ExchangeEntity>>
    {
        private readonly Service service;

        public Handler(Service service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<ExchangeEntity>> Handle(HttpParameterJson message)
        {
            
            return await service.Query(message).ConfigureAwait(false);
        }
    }
}