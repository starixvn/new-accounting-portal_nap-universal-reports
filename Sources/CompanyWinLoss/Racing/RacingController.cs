using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Racing
{
    [RoutePrefix("api/company-win-loss/racing")]
    public class RacingController : ApiController
    {
        private readonly BetTypeService _betTypeService;

        private readonly SiteService _siteService;

        private readonly SportTypeService _sportTypeService;

        private readonly MatchDetail.Service _matchDetailService;

        public RacingController(
            BetTypeService betTypeService,
            SiteService siteService,
            SportTypeService sportTypeService,
            MatchDetail.Service matchDetailService)
        {
            _betTypeService = betTypeService;
            _siteService = siteService;
            _sportTypeService = sportTypeService;
            _matchDetailService = matchDetailService;
        }

        [Route("sport-type")]
        public SportTypeWinLossModel SportType(SportType.QueryModel queryModel)
        {
            var criteria = new SportType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? _sportTypeService.Query(criteria)
                : null;
        }

        [Route("bet-type")]
        public BetTypeWinLossModel Summary(BetType.QueryModel queryModel)
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

        [Route("site")]
        public SiteWinLoss Site(Site.QueryModel queryModel)
        {
            var criteria = new Site.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                BetType = queryModel.BetType,
                Site = queryModel.Site
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
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
                SportType = queryModel.SportType
            };

            return ModelState.IsValid
                ? _matchDetailService.Query(criteria)
                : null;
        }
    }
}
