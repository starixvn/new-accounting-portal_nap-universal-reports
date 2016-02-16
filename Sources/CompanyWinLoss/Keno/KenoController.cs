using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Keno
{
    [RoutePrefix("api/company-win-loss/keno")]
    public class KenoController : ApiController
    {
        private readonly BetTypeService betTypeService;

        private readonly SiteService siteService;

        public KenoController(
            BetTypeService betTypeService,
            SiteService siteService)
        {
            this.betTypeService = betTypeService;
            this.siteService = siteService;
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
                BetType = queryModel.BetType,
                Site = queryModel.Site
            };

            return ModelState.IsValid
                ? siteService.Query(criteria)
                : null;
        }
    }
}
