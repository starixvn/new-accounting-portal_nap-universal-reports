using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class Handler : IRequestHandler<HttpParameterJson, SummaryEntity<BetCountModel>>
    {
        private readonly BetCountService betCountService;

        public Handler(BetCountService betCountService)
        {
            this.betCountService = betCountService;
        }

        public async Task<SummaryEntity<BetCountModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            return await betCountService.Query(criteria);
        }
    }
}