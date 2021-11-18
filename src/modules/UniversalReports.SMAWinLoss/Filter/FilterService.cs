using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Filter
{
    public interface FilterService
    {
        Task<IEnumerable<Currency>> GetCurrencies();

        Task<IEnumerable<Site>> GetSites();

        Task<IEnumerable<Sport>> GetSports();

        Task<IEnumerable<LeagueGroup>> GetLeagueGroup();

        Task<bool> GetAvailableDatabase();

        Task<string> GetAvailableDateData();
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

        public async Task<IEnumerable<LeagueGroup>> GetLeagueGroup()
        {
            var criteria = new LeagueGroupCriteria();
            return await repository.FetchAsync<LeagueGroup>(criteria);
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
    }
}