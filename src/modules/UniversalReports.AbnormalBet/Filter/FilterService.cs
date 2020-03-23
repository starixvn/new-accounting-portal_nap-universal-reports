using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Filter
{
    public interface FilterService
    {
        Task<IEnumerable<SportModel>> QuerySport();

        Task<IEnumerable<ReasonModel>> QueryReason();

        Task<IEnumerable<SiteModel>> QuerySite();

        Task<IEnumerable<BetTypeModel>> QueryBetType(int sportId);
    }

    public class FilterServiceImp : FilterService
    {
        private readonly IDynamicRepository repository;

        public FilterServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BetTypeModel>> QueryBetType(int sportId)
        {
            return await repository.FetchAsync<BetTypeModel>(new BetTypeQueryCriteria
            {
                SportId = sportId
            });
        }

        public async Task<IEnumerable<SiteModel>> QuerySite()
        {
            return await repository.FetchAsync<SiteModel>(new SiteQueryCriteria());
        }

        public async Task<IEnumerable<ReasonModel>> QueryReason()
        {
            return await repository.FetchAsync<ReasonModel>(new ReasonQueryCriteria());
        }

        public async Task<IEnumerable<SportModel>> QuerySport()
        {
            return await repository.FetchAsync<SportModel>(new SportQueryCriteria());
        }
    }
}
