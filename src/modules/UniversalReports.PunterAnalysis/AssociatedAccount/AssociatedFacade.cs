using Fanex.Data.Repository;
using Linq.DynamicSum;
using Olympus.FPSAPI.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public interface AssociatedFacade
    {
        Task<SummaryEntity<AssociatedSummaryModel>> Query(HttpParameterJson request);
    }

    public class AssociatedFacadeImp : AssociatedFacade
    {
        private readonly IDynamicRepository repository;

        private readonly FraudServiceWrapper fraudServiceWrapper;

        private readonly ConfigurationService configurationService;

        public AssociatedFacadeImp(ConfigurationService configurationService, FraudServiceWrapper fraudServiceWrapper, IDynamicRepository repository)
        {
            this.configurationService = configurationService;
            this.fraudServiceWrapper = fraudServiceWrapper;
            this.repository = repository;
        }

        public async Task<SummaryEntity<AssociatedSummaryModel>> Query(HttpParameterJson request)
        {
            var associatedCustomers = await fraudServiceWrapper.GetAssociatedCustomers(configurationService.FraudSystemApi, request.CustId);

            var usernames = associatedCustomers.Select(c => c.Account.ToLowerInvariant()).Distinct();
            var summaries = usernames.Any()
                ? await GetMemberSummaries(request, usernames)
                : new List<AssociatedSummaryModel>();

            return summaries
                .CalculateSummaryEntity();
        }

        private async Task<List<AssociatedSummaryModel>> GetMemberSummaries(HttpParameterJson request, IEnumerable<string> usernames)
        {
            var usernameInString = string.Join(",", usernames);
            var criteria = new MemberPerformanceCriteria
            {
                Username = usernameInString,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                LeagueId = request.LeagueId,
                ListCombinationId = request.ListCombinationId,
                OrderBy = request.OrderBy,
                PeriodType = request.PeriodType,
                SortBy = request.SortBy,
                ListLeagueGroupId = request.ListLeagueGroupId
            };

            var summaries = await repository.FetchAsync<AssociatedSummaryModel>(criteria);

            foreach (var item in summaries)
            {
                item.Category = await fraudServiceWrapper.GetCategory(configurationService.FraudSystemCategoryApi, item.CustId.ToString());
            }

            return summaries.ToList();
        }
    }
}