using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace UniversalReports.SMAWinLoss.Filter
{
    public interface FilterService
    {
        Task<IEnumerable<Currency>> GetCurrencies();

        Task<IEnumerable<Site>> GetSites();

        Task<IEnumerable<Sport>> GetSports();

        Task<IEnumerable<string>> GetLeagueGroupBySport(LeagueGroupHttpParameter parameter);
    }

    public class FilterServiceImp : FilterService
    {
        private const int startYear = 2020;
        private readonly IDynamicRepository repository;

        public FilterServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var criteria = new CurrencyCriteria();
            return await repository.FetchAsync<Currency>(criteria);
        }

        public async Task<IEnumerable<string>> GetLeagueGroupBySport(LeagueGroupHttpParameter parameter)
        {
            var criteria = Mapper.Map<LeagueGroupCriteria>(parameter);
            return await repository.FetchAsync<string>(criteria);
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