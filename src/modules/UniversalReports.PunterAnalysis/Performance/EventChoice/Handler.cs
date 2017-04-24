using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Performance.EventChoice
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<EventChoiceModel>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<EventChoiceModel>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<EventChoiceModel>(criteria);
        }
    }
}
