using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Keno
{
    [RoutePrefix("api/company-win-loss/keno")]
    public class KenoController : ApiController
    {
        private readonly BetTypeService _betTypeService;

        private readonly SiteService _siteService;

        public KenoController(
            BetTypeService betTypeService,
            SiteService siteService)
        {
            _betTypeService = betTypeService;
            _siteService = siteService;
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
    }
}
