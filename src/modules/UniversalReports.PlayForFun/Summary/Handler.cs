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
        private readonly PlayForFunService playForFunService;

        public Handler(PlayForFunService playForFunService)
        {
            this.playForFunService = playForFunService;
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson message)
        {
            var criteria = Mapper.Map<SummaryCriteria>(message);
            var model = await playForFunService.Query<SummaryModel>(criteria).ConfigureAwait(false);

            var viewModel = Mapper.Map<SummaryEntity<SummaryModel>>(model);

            return viewModel;
        }
    }
}