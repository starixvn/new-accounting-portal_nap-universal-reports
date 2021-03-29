using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.Services
{
    public interface CashOutPerformanceService
    {
        Task<IEnumerable<SportModel>> GetSports(SportCriteria criteria);
        Task<IEnumerable<LicenseeModel>> GetLicensees(LicenseeCriteria criteria);
        Task<SummaryEntity<TicketModel>> GetTickets(TicketCriteria criteria);
    }

    public class CashOutPerformanceServiceImp : CashOutPerformanceService
    {
        private readonly IDynamicRepository repository;

        public CashOutPerformanceServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LicenseeModel>> GetLicensees(LicenseeCriteria criteria)
        {
            return await repository.FetchAsync<LicenseeModel>(criteria);
        }

        public async Task<IEnumerable<SportModel>> GetSports(SportCriteria criteria)
        {
            return await repository.FetchAsync<SportModel>(criteria);
        }

        public async Task<SummaryEntity<TicketModel>> GetTickets(TicketCriteria criteria)
        {
            return (await repository.FetchAsync<TicketModel>(criteria)).CalculateSummaryEntity();
        }
    }
}
