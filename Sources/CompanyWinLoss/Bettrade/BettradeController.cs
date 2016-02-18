using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Bettrade
{
    [RoutePrefix("api/company-win-loss/bettrade")]
    public class BettradeController : ApiController
    {
        private readonly BetTypeService betTypeService;

        private readonly SiteService siteService;

        public BettradeController(BetTypeService betTypeService,
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
            return ModelState.IsValid ?
                    betTypeService.Query(criteria) :
                    null;
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
            return ModelState.IsValid ?
                    siteService.Query(criteria) :
                    null;
        }
    }
}
