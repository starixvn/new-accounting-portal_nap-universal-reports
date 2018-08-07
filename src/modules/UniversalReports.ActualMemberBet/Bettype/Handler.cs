using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class Handler : IAsyncRequestHandler<HttpParameter, SummaryEntity<BetTypeActualMemberBet>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<BetTypeActualMemberBet>> Handle(HttpParameter message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return (await repository.FetchAsync<BetTypeActualMemberBet>(criteria).ConfigureAwait(false)).CalculateSummaryEntity();
        }
    }
}
