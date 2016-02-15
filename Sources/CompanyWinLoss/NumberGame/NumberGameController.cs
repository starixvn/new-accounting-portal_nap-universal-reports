using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame
{
    [RoutePrefix("api/company-win-loss/number-game")]
    public class NumberGameController : ApiController
    {
        private readonly BetType.Service _betTypeService;

        private readonly MatchDetail.Service _detailService;

        private readonly SiteService _siteService;

        public NumberGameController(
            BetType.Service betTypeService,
            MatchDetail.Service detailService,
            SiteService siteService)
        {
            _betTypeService = betTypeService;
            _detailService = detailService;
            _siteService = siteService;
        }

        [Route("bet-type")]
        public BetType.WinLossModel Summary(BetType.QueryModel queryModel)
        {
            var criteria = new BetType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? _betTypeService.Query(criteria)
                : null;
        }

        [Route("match-detail")]
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

        [Route("site")]
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
