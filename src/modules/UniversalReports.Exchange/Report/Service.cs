using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;

namespace UniversalReports.Exchange.Report
{
    public interface Service
    {
        Task<SummaryEntity<ExchangeEntity>> Query(HttpParameterJson message);
    }

    public class ServiceImp : Service
    {
        private readonly IDynamicRepository repository;

        public ServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<ExchangeEntity>> Query(HttpParameterJson message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            return (await repository.FetchAsync<ExchangeEntity>(criteria).ConfigureAwait(false))
                    .CalculateSummaryEntity();
        }
    }
}
