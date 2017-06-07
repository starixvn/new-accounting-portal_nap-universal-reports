using Fanex.Data.Repository;
using MediatR;
using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Filter.AvailableDateRange
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, DateRange>
    {
        private readonly IDynamicRepository repository;

        public Handler(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DateRange> Handle(HttpParameterJson message)
        {
            var criteria = new QueryCriteria();
            return await repository.GetAsync<DateRange>(criteria).ConfigureAwait(false);
        }
    }
}