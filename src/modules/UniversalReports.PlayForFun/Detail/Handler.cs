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
        private readonly IMapper mapper;

        private readonly PlayForFunService playForFunService;

        public Handler(IMapper mapper, PlayForFunService playForFunService)
        {
            this.mapper = mapper;
            this.playForFunService = playForFunService;
        }

        public async Task<SummaryEntity<DetailModel>> Handle(HttpParameterJson message)
        {
            var criteria = mapper.Map<DetailCriteria>(message);
            return await playForFunService.Query<DetailModel>(criteria);
        }
    }
}