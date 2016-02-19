using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.Site
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoSiteController : ApiController
    {
        private readonly SiteService siteService;
        private readonly SiteGridOptionService siteGridOptionService;

        public LiveCasinoSiteController(SiteService siteService, SiteGridOptionService siteGridOptionService)
        {
            this.siteService = siteService;
            this.siteGridOptionService = siteGridOptionService;
        }

        [Route("site")]
        public IHttpActionResult Site(Site.QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Site.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    BetType = queryModel.BetType,
                    Site = queryModel.Site
                };

                var siteWinLoss = this.siteService.Query(criteria);
                var gridOptions = this.siteGridOptionService.FromSiteWinLoss(siteWinLoss, queryModel.Site, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
