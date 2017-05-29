using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Detail
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, SummaryEntity<DetailModel>>
    {
        private readonly PlayForFunService playForFunService;

        public Handler(PlayForFunService playForFunService)
        {
            this.playForFunService = playForFunService;
        }

        public async Task<SummaryEntity<DetailModel>> Handle(HttpParameterJson message)
        {
            var criteria = Mapper.Map<DetailCriteria>(message);
            return await playForFunService.Query<DetailModel>(criteria).ConfigureAwait(false);
        }
    }
}