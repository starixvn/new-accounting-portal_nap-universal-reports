using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports
{
    public class VirtualSportsController : ApiController
    {
        private readonly Summary.Service _summaryService;

        private readonly BetType.Service _betTypeService;

        private readonly RacingMatchDetail.Service _racingService;

        private readonly SportsbookMatchDetail.Service _sportsbookService;

        private readonly SiteService _siteService;

        public VirtualSportsController(
            Summary.Service summaryService,
            BetType.Service betTypeService,
            RacingMatchDetail.Service racingService,
            SportsbookMatchDetail.Service sportsbookService,
            SiteService siteService)
        {
            _summaryService = summaryService;
            _betTypeService = betTypeService;
            _racingService = racingService;
            _sportsbookService = sportsbookService;
            _siteService = siteService;
        }

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

        public BetType.WinLossModel BetType(BetType.QueryModel queryModel)
        {
            var criteria = new BetType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType,
            };

            return ModelState.IsValid
                ? _betTypeService.Query(criteria)
                : null;
        }

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
