using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class OddsHandler : IAsyncRequestHandler<OddsHttpParameter, IEnumerable<Odds>>
    {
        private readonly IDynamicRepository repository;

        public OddsHandler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Odds>> Handle(OddsHttpParameter message)
        {
            var criteria = new OddsCriteria();
            return await repository.FetchAsync<Odds>(criteria).ConfigureAwait(false);
        }
    }
}
