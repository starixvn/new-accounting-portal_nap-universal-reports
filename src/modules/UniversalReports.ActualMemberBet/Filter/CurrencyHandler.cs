using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class CurrencyHandler : IAsyncRequestHandler<CurrencyHttpParameter, IEnumerable<Currency>>
    {
        private readonly IDynamicRepository repository;

        public CurrencyHandler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Currency>> Handle(CurrencyHttpParameter message)
        {
            var criteria = new CurrencyCriteria();
            return await repository.FetchAsync<Currency>(criteria).ConfigureAwait(false);
        }
    }
}
