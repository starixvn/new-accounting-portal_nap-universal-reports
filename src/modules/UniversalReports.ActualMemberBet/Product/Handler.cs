using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using MediatR;

namespace UniversalReports.ActualMemberBet.Product
{
    public class Handler : IAsyncRequestHandler<HttpParameter, SummaryEntity<ProductActualMemberBet>>
    {

        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<ProductActualMemberBet>> Handle(HttpParameter message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return (await repository.FetchAsync<ProductActualMemberBet>(criteria).ConfigureAwait(false)).CalculateSummaryEntity();
        }
    }
}
