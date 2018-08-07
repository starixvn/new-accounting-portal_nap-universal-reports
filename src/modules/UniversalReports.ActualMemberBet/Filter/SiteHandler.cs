using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    public class SiteHandler : IAsyncRequestHandler<SiteHttpParameter, IEnumerable<Site>>
    {
        private readonly IDynamicRepository repository;

        public SiteHandler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Site>> Handle(SiteHttpParameter message)
        {
            var criteria = new SiteCriteria();
            return await repository.FetchAsync<Site>(criteria).ConfigureAwait(false);
        }
    }
}
