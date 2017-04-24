using Fanex.Data.Repository;
using MediatR;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Performance.Margin
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, MarginModel>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MarginModel> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.GetAsync<MarginModel>(criteria);
        }
    }
}
