using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, IEnumerable<SummaryModel>>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SummaryModel>> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.FetchAsync<SummaryModel>(criteria);
        }
    }
}
