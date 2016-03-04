using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Casino.Site
{
    [RoutePrefix("api/company-win-loss/casino/site")]
    public class CasinoSiteController : ApiController
    {
        private readonly SiteService winlossService;
        private readonly SiteGridOptionService gridOptionService;

        public CasinoSiteController(SiteService siteService, SiteGridOptionService gridOptionService)
        {
            this.winlossService = siteService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult Site(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    BetType = queryModel.BetType,
                    Site = queryModel.Site
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Site, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    BetType = queryModel.BetType,
                    Site = queryModel.Site
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Site, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}