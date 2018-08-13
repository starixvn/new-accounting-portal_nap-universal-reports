using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Product
{
    public class Handler : IAsyncRequestHandler<HttpParameter, SummaryEntity<ProductActualMemberBet>>
    {

        private readonly ActualMemberBetService service;

        public Handler(ActualMemberBetService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<ProductActualMemberBet>> Handle(HttpParameter message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return await service.Query<ProductActualMemberBet>(criteria).ConfigureAwait(false);
        }
    }
}
