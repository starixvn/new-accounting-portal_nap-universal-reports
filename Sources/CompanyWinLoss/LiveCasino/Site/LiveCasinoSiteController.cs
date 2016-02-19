using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.Site
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoSiteController : ApiController
    {
        private readonly SiteService _siteService;
        private readonly SiteGridOptionService _siteGridOptionService;

        public LiveCasinoSiteController(SiteService siteService, SiteGridOptionService siteGridOptionService)
        {
            _siteService = siteService;
            _siteGridOptionService = siteGridOptionService;
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

                var siteWinLoss = _siteService.Query(criteria);
                var gridOptions = _siteGridOptionService.FromSiteWinLoss(siteWinLoss, queryModel.Site, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
