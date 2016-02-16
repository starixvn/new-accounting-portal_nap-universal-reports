using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsController : ApiController
    {
        private readonly SportTypeService sportTypeService;

        private readonly BetTypeService betTypeService;

        private readonly RacingMatchDetail.Service racingService;

        private readonly SportsbookMatchDetail.Service sportsbookService;

        private readonly SiteService siteService;

        public VirtualSportsController(
            SportTypeService sportTypeService,
            BetTypeService betTypeService,
            RacingMatchDetail.Service racingService,
            SportsbookMatchDetail.Service sportsbookService,
            SiteService siteService)
        {
            this.sportTypeService = sportTypeService;
            this.betTypeService = betTypeService;
            this.racingService = racingService;
            this.sportsbookService = sportsbookService;
            this.siteService = siteService;
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
                ? sportTypeService.Query(criteria)
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
                ? betTypeService.Query(criteria)
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
                ? siteService.Query(criteria)
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
                ? racingService.Query(criteria)
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
                ? sportsbookService.Query(criteria)
                : null;
        }
    }
}
