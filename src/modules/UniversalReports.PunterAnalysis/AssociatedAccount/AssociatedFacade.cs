using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AssociatedFacadeImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<AssociatedSummaryModel>> Query(HttpParameterJson request)
        {
            var summaries = await GetMemberSummaries(request);

            return summaries
                .CalculateSummaryEntity();
        }

        private async Task<List<AssociatedSummaryModel>> GetMemberSummaries(HttpParameterJson request)
        {
            var criteria = new MemberPerformanceCriteria
            {
                CustIds = request.CustId.ToString(),
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
            return summaries.ToList();
        }
    }
}