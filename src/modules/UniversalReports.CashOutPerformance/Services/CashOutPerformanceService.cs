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
        Task<IEnumerable<FilterGroupItemModel>> GetSportBettypes(SportCriteria criteria);

        Task<IEnumerable<SiteModel>> GetLicensees(LicenseeCriteria criteria);

        Task<TicketViewModel<T>> GetTickets<T, U>(U criteria);

        Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria);

        Task<IEnumerable<FilterItemModel>> GetLeagueGroups(LeagueGroupCriteria criteria);
    }

    public class CashOutPerformanceServiceImp : CashOutPerformanceService
    {
        private readonly IDynamicRepository repository;

        public CashOutPerformanceServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<SiteModel>> GetLicensees(LicenseeCriteria criteria)
        {
            return await repository.FetchAsync<SiteModel>(criteria);
        }

        public async Task<IEnumerable<FilterGroupItemModel>> GetSportBettypes(SportCriteria criteria)
        {
            var sportBettype = await repository.FetchAsync<SportBetTypeModel>(criteria);
            var groups = sportBettype.GroupBy(x => new { x.SportType, x.SportName });
            var result = new List<FilterGroupItemModel>();
            foreach (var group in groups)
            {
                var model = new FilterGroupItemModel
                {
                    GroupId = group.Key.SportType,
                    GroupName = group.Key.SportName,
                    ChildItems = group.Select(x => new FilterItemModel { Id = x.Bettype, Name = x.BettypeName }).ToList()
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<TicketViewModel<T>> GetTickets<T, U>(U criteria)
        {
            var (firstResultSet, secondResultSet, thirdResultSet) = await repository.FetchMultipleAsync<T, T, int>((ICriteria)criteria);
            return new TicketViewModel<T>
            {
                TicketList = firstResultSet,
                TotalTicket = secondResultSet.FirstOrDefault(),
                Total = thirdResultSet.FirstOrDefault()
            };
        }

        public async Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria)
        {
            return await repository.FetchAsync<LeagueModel>(criteria);
        }

        public async Task<IEnumerable<FilterItemModel>> GetLeagueGroups(LeagueGroupCriteria criteria)
        {
            return await repository.FetchAsync<FilterItemModel>(criteria);
        }
    }
}