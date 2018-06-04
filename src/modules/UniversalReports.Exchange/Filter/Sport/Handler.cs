using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.Exchange.Filter.Sport
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<SportEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SportEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new Criteria();
            return await repository.FetchAsync<SportEntity>(criteria).ConfigureAwait(false);
        }
    }
}