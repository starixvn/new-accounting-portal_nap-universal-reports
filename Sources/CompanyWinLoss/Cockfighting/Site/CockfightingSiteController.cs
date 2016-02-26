using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Cockfighting.Site
{
    [RoutePrefix("api/company-win-loss/cock-fighting")]
    public class CockfightingSiteController : ApiController
    {
        private readonly SiteService winlossService;
        private readonly SiteGridOptionService gridOptionService;

        public CockfightingSiteController(SiteService siteService, SiteGridOptionService gridOptionService)
        {
            this.winlossService = siteService;
            this.gridOptionService = gridOptionService;
        }

        [Route("site")]
        public IHttpActionResult Site(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    Site = queryModel.Site
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Site);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
