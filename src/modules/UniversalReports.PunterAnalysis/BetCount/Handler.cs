using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ReportModelBase<BetCountModel>>
    {
        private readonly IMapper mapper;

        private readonly BetCountService betCountService;

        public Handler(IMapper mapper, BetCountService betCountService)
        {
            this.mapper = mapper;
            this.betCountService = betCountService;
        }

        public async Task<ReportModelBase<BetCountModel>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);
            return await betCountService.Query(criteria);
        }
    }
}
