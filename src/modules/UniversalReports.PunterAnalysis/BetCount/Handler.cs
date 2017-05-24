using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, SummaryEntity<BetCountModel>>
    {
        private readonly IMapper mapper;

        private readonly BetCountService betCountService;

        public Handler(IMapper mapper, BetCountService betCountService)
        {
            this.mapper = mapper;
            this.betCountService = betCountService;
        }

        public async Task<SummaryEntity<BetCountModel>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);
            return await betCountService.Query(criteria);
        }
    }
}
