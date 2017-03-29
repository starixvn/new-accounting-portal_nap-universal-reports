using Fanex.Data.Repository;
using MediatR;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.AvailableDateRange
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, Entity>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Entity> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.GetAsync<Entity>(criteria);
        }
    }
}