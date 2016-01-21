using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class NumberGameWinLossController : ApiController
    {
        private NumberGameBetTypeSummaryWinLossService _summaryService;

        private NumberGameMatchDetailWinLossService _detailService;

        private SiteWinLossService _siteService;

        public NumberGameWinLossController(
            NumberGameBetTypeSummaryWinLossService summaryService,
            NumberGameMatchDetailWinLossService detailService,
            SiteWinLossService siteWinLossService)
        {
            _summaryService = summaryService;
            _detailService = detailService;
            _siteService = siteWinLossService;
        }

        public NumberGameBetTypeWinLossSummary Summary(NumberGameQuery query)
        {
            var criteria = new NumberGameBetTypeSummaryWinLossCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return ModelState.IsValid
                ? _summaryService.Query(criteria)
                : null;
        }

        public NumberGameMatchDetailWinLoss MatchDetail(NumberGameMatchDetailQuery query)
        {
            var criteria = new NumberGameMatchDetailWinLossCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                BetType = query.BetType,
                IsLive = query.IsLive,
                SportType = query.SportType
            };

            return ModelState.IsValid
                ? _detailService.Query(criteria)
                : null;
        }

        public SiteWinLoss SiteWinLoss(NumberGameSiteQuery query)
        {
            var criteria = new NumberGameSiteWinLossCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                SportType = query.SportType,
                BetType = query.BetType,
                IsLive = query.IsLive,
                Site = query.Site
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
                : null;
        }
    }
}
