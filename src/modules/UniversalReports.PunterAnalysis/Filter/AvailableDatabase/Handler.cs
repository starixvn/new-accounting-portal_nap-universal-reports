using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.AvailableDatabase
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, bool>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.GetAsync<bool>(criteria).ConfigureAwait(false);
        }
    }
}