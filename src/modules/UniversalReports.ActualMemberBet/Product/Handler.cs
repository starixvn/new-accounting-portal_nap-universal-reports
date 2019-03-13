using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Product
{
    public class Handler : IRequestHandler<HttpParameter, SummaryEntity<ProductActualMemberBet>>
    {

        private readonly ActualMemberBetService service;

        public Handler(ActualMemberBetService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<ProductActualMemberBet>> Handle(HttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            return await service.Query<ProductActualMemberBet>(criteria);
        }
    }
}
