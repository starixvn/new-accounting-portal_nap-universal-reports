using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, SummaryEntity<BetCountModel>>
    {
        private readonly BetCountService betCountService;

        public Handler(BetCountService betCountService)
        {
            this.betCountService = betCountService;
        }

        public async Task<SummaryEntity<BetCountModel>> Handle(HttpParameterJson message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return await betCountService.Query(criteria).ConfigureAwait(false);
        }
    }
}