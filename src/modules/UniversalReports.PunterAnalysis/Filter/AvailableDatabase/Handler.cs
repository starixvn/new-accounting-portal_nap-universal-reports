using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;

namespace UniversalReports.PunterAnalysis.Filter.AvailableDatabase
{
    public class Handler : IRequestHandler<HttpParameterJson, bool>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = new QueryCriteria();
            return await repository.GetAsync<bool>(criteria);
        }
    }
}