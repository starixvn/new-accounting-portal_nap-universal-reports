using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ViewModelJson>
    {
        private readonly IMapper mapper;

        private readonly BetCountService betCountService;

        public Handler(IMapper mapper, BetCountService betCountService)
        {
            this.mapper = mapper;
            this.betCountService = betCountService;
        }

        public async Task<ViewModelJson> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await betCountService.Query(criteria);

            var viewModel = mapper.Map<ViewModelJson>(model);

            return viewModel;
        }
    }
}
