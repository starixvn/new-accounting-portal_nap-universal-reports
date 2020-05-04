using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Filter
{
    public interface FilterService
    {
        Task<IEnumerable<FilterItemModel>> QuerySport();

        Task<IEnumerable<FilterItemModel>> QueryReason();

        Task<IEnumerable<FilterItemModel>> QuerySite();

        Task<IEnumerable<FilterItemModel>> QueryBetType(string sportId);
    }

    public class FilterServiceImp : FilterService
    {
        private readonly IDynamicRepository repository;

        public FilterServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<FilterItemModel>> QueryBetType(string sportId)
        {
            return await repository.FetchAsync<FilterItemModel>(new BetTypeQueryCriteria
            {
                SportId = sportId
            });
        }

        public async Task<IEnumerable<FilterItemModel>> QuerySite()
        {
            return await repository.FetchAsync<FilterItemModel>(new SiteQueryCriteria());
        }

        public async Task<IEnumerable<FilterItemModel>> QueryReason()
        {
            return await repository.FetchAsync<FilterItemModel>(new ReasonQueryCriteria());
        }

        public async Task<IEnumerable<FilterItemModel>> QuerySport()
        {
            return await repository.FetchAsync<FilterItemModel>(new SportQueryCriteria());
        }
    }
}
