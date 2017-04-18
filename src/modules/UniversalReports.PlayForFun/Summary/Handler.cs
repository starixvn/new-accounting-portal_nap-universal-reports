using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, ViewModelJson>
    {
        private readonly IMapper mapper;

        private readonly PlayForFunService playForFunService;

        public Handler(IMapper mapper, PlayForFunService playForFunService)
        {
            this.mapper = mapper;
            this.playForFunService = playForFunService;
        }

        public async Task<ViewModelJson> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await playForFunService.Query<SummaryModel>(criteria);

            var viewModel = mapper.Map<ViewModelJson>(model);

            return viewModel;
        }
    }
}