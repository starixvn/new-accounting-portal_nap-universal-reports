using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsController : ApiController
    {
        private readonly SportTypeService _sportTypeService;

        private readonly BetTypeService _betTypeService;

        private readonly RacingMatchDetail.Service _racingService;

        private readonly SportsbookMatchDetail.Service _sportsbookService;

        private readonly SiteService _siteService;

        public VirtualSportsController(
            SportTypeService sportTypeService,
            BetTypeService betTypeService,
            RacingMatchDetail.Service racingService,
            SportsbookMatchDetail.Service sportsbookService,
            SiteService siteService)
        {
            _sportTypeService = sportTypeService;
            _betTypeService = betTypeService;
            _racingService = racingService;
            _sportsbookService = sportsbookService;
            _siteService = siteService;
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
        public BetTypeWinLossModel BetType(BetType.QueryModel queryModel)
        {
            var criteria = new BetType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType
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
                SportType = queryModel.SportType,
                Site = queryModel.Site,
                BetType = queryModel.BetType
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
                : null;
        }

        [Route("racing-match-detail")]
        public RacingMatchDetail.WinLossModel RacingMatchDetail(RacingMatchDetail.QueryModel queryModel)
        {
            var criteria = new RacingMatchDetail.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType,
                BetType = queryModel.BetType
            };

            return ModelState.IsValid
                ? _racingService.Query(criteria)
                : null;
        }

        [Route("sports-book-match-detail")]
        public SportsbookMatchDetail.WinLossModel SportsbookMatchDetail(SportsbookMatchDetail.QueryModel queryModel)
        {
            var criteria = new SportsbookMatchDetail.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType,
                BetType = queryModel.BetType
            };

            return ModelState.IsValid
                ? _sportsbookService.Query(criteria)
                : null;
        }
    }
}
