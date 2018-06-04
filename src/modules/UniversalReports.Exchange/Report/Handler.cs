using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<ExchangeEntity>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ExchangeEntity>> Handle(HttpParameterJson message)
        {
            var criteria = new Criteria();
            return await repository.FetchAsync<ExchangeEntity>(criteria).ConfigureAwait(false);
        }
    }
}