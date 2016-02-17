using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Keno
{
    [RoutePrefix("api/company-win-loss/keno")]
    public class SiteController : ApiController
    {

        private readonly SiteService siteService;

        private readonly SiteGridOptionService siteGridOptionService;

        public SiteController(SiteService siteService, SiteGridOptionService siteGridOptionService)
        {
            this.siteService = siteService;
            this.siteGridOptionService = siteGridOptionService;
        }

        [Route("site")]
        public GridOptions Site(Site.QueryModel queryModel)
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
                var winLoss = siteService.Query(criteria);
                return siteGridOptionService.FromSiteWinLoss(winLoss);
            }

            return null;
        }
    }
}
