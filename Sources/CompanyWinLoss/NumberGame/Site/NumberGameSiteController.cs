using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.NumberGame.Site
{
    [RoutePrefix("api/company-win-loss/number-game/site")]
    public class NumberGameSiteController : ApiController
    {
        private readonly SiteService winlossService;
        private readonly SiteGridOptionService gridOptionService;

        public NumberGameSiteController(SiteService siteService, SiteGridOptionService gridOptionService)
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
                    SportType = queryModel.SportType,
                    BetType = queryModel.BetType,
                    IsLive = queryModel.IsLive,
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
                    SportType = queryModel.SportType,
                    BetType = queryModel.BetType,
                    IsLive = queryModel.IsLive,
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