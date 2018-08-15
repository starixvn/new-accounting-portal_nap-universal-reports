using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class Handler : IRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        private readonly PlayForFunService playForFunService;

        public Handler(PlayForFunService playForFunService)
        {
            this.playForFunService = playForFunService;
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SummaryCriteria>(request);
            var model = await playForFunService.Query<SummaryModel>(criteria).ConfigureAwait(false);

            var viewModel = Mapper.Map<SummaryEntity<SummaryModel>>(model);

            return viewModel;
        }
    }
}