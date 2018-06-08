using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.Exchange.Filter.Licensee
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<LicenseeModel>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LicenseeModel>> Handle(HttpParameterJson message)
        {
            var criteria = new Criteria();
            return await repository.FetchAsync<LicenseeModel>(criteria).ConfigureAwait(false);
        }
    }
}