using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame
{
    public class NumberGameController : ApiController
    {
        private readonly Summary.Service _summaryService;

        private readonly MatchDetail.Service _detailService;

        private readonly SiteService _siteService;

        public NumberGameController(
            Summary.Service summaryService,
            MatchDetail.Service detailService,
            SiteService siteService)
        {
            _summaryService = summaryService;
            _detailService = detailService;
            _siteService = siteService;
        }

        [Route("api/number-game/summary")]
        public Summary.WinLossModel Summary(Summary.QueryModel queryModel)
        {
            var criteria = new Summary.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? _summaryService.Query(criteria)
                : null;
        }

        [Route("api/number-game/match-detail")]
        public MatchDetail.WinLossModel MatchDetail(MatchDetail.QueryModel queryModel)
        {
            var criteria = new MatchDetail.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                BetType = queryModel.BetType,
                IsLive = queryModel.IsLive,
                SportType = queryModel.SportType
            };

            return ModelState.IsValid
                ? _detailService.Query(criteria)
                : null;
        }

        [Route("api/number-game/site")]
        public SiteWinLoss Site(Site.QueryModel queryModel)
        {
            var criteria = new Site.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType,
                BetType = queryModel.BetType,
                IsLive = queryModel.IsLive,
                Site = queryModel.Site
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
                : null;
        }
    }
}
