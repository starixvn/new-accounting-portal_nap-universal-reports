using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        private readonly IMapper mapper;

        private readonly PlayForFunService playForFunService;

        public Handler(IMapper mapper, PlayForFunService playForFunService)
        {
            this.mapper = mapper;
            this.playForFunService = playForFunService;
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<SummaryCriteria>(message);
            var model = await playForFunService.Query<SummaryModel>(criteria).ConfigureAwait(false);

            var viewModel = mapper.Map<SummaryEntity<SummaryModel>>(model);

            return viewModel;
        }
    }
}