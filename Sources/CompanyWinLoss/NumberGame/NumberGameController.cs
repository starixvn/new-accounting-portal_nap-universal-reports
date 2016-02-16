using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.NumberGame
{
    [RoutePrefix("api/company-win-loss/number-game")]
    public class NumberGameController : ApiController
    {
        private readonly BetType.Service betTypeService;

        private readonly MatchDetail.Service detailService;

        private readonly SiteService siteService;

        public NumberGameController(
            BetType.Service betTypeService,
            MatchDetail.Service detailService,
            SiteService siteService)
        {
            this.betTypeService = betTypeService;
            this.detailService = detailService;
            this.siteService = siteService;
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
                ? betTypeService.Query(criteria)
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
                ? detailService.Query(criteria)
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
                ? siteService.Query(criteria)
                : null;
        }
    }
}
