using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class Handler : IAsyncRequestHandler<HttpParameter, SummaryEntity<BetTypeActualMemberBet>>
    {
        private readonly ActualMemberBetService service;

        public Handler(ActualMemberBetService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<BetTypeActualMemberBet>> Handle(HttpParameter message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return await service.Query<BetTypeActualMemberBet>(criteria).ConfigureAwait(false);
        }
    }
}
