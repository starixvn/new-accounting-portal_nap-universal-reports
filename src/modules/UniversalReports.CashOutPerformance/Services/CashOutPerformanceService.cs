using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Services
{
    public interface CashOutPerformanceService
    {
        Task<IEnumerable<FilterItemModel>> GetSports(SportCriteria criteria);

        Task<IEnumerable<FilterItemModel>> GetLicensees(LicenseeCriteria criteria);

        Task<TicketViewModel> GetTickets(TicketCriteria criteria);

        Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria);
    }

    public class CashOutPerformanceServiceImp : CashOutPerformanceService
    {
        private readonly IDynamicRepository repository;

        public CashOutPerformanceServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<FilterItemModel>> GetLicensees(LicenseeCriteria criteria)
        {
            return await repository.FetchAsync<FilterItemModel>(criteria);
        }

        public async Task<IEnumerable<FilterItemModel>> GetSports(SportCriteria criteria)
        {
            return await repository.FetchAsync<FilterItemModel>(criteria);
        }

        public async Task<TicketViewModel> GetTickets(TicketCriteria criteria)
        {
            var data = await repository.FetchMultipleAsync<TicketModel, TicketModel, int>(criteria);
            return new TicketViewModel
            {
                TicketList = data.firstResultSet,
                TotalTicket = data.secondResultSet.FirstOrDefault(),
                Total = data.thirdResultSet.FirstOrDefault()
            };
        }

        public async Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria)
        {
            return await repository.FetchAsync<LeagueModel>(criteria);
        }
    }
}