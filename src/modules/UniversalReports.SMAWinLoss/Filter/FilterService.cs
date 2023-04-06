using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Filter
{
    public interface FilterService
    {
        Task<IEnumerable<Currency>> GetCurrencies();

        Task<IEnumerable<Site>> GetSites();

        Task<IEnumerable<Sport>> GetSports();

        Task<List<LeagueGroup>> GetLeagueGroup();

        Task<bool> GetAvailableDatabase();

        Task<string> GetAvailableDateData();

        Task<IEnumerable<BetFrom>> GetBetFroms();
    }

    public class FilterServiceImp : FilterService
    {
        private readonly IDynamicRepository repository;

        public FilterServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> GetAvailableDatabase()
        {
            var criteria = new AvailableDatabaseCriteria();
            return await repository.GetAsync<bool>(criteria);
        }

        public async Task<string> GetAvailableDateData()
        {
            var criteria = new AvailableDateDataCriteria();
            var date = await repository.GetAsync<DateTime>(criteria);
            return $"{date: MMM dd, yyyy}";
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var criteria = new CurrencyCriteria();
            return await repository.FetchAsync<Currency>(criteria);
        }

        public async Task<List<LeagueGroup>> GetLeagueGroup()
        {
            var result = new List<LeagueGroup>();

            var criteria = new LeagueGroupCriteria();

            var leagueGroupChildItems = await repository.FetchAsync<LeagueGroupChildItem>(criteria);

            var leagueGroups = leagueGroupChildItems.GroupBy(x => x.Label);

            foreach (var group in leagueGroups)
            {
                var childItems = leagueGroupChildItems.Where(x => x.Label == group.Key);

                var leagueGroupItem = new LeagueGroup
                {
                    GroupName = group.Key,
                    LeagueIds = childItems.Select(x => x.LeagueIds).FirstOrDefault(),
                    ChildItems = childItems
                };

                result.Add(leagueGroupItem);
            }


            return result;
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            var criteria = new SiteCriteria();
            return await repository.FetchAsync<Site>(criteria);
        }

        public async Task<IEnumerable<Sport>> GetSports()
        {
            var criteria = new SportCriteria();
            return await repository.FetchAsync<Sport>(criteria);
        }

        public async Task<IEnumerable<BetFrom>> GetBetFroms()
        {
            var criteria = new BetFromCriteria();
            return await repository.FetchAsync<BetFrom>(criteria);
        }
    }
}