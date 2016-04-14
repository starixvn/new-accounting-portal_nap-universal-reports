using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Bingo.Site
{
    [RoutePrefix("api/company-win-loss/bingo/site")]
    public class BingoSiteController : ApiController
    {
        private readonly SiteService winlossService;
        private readonly SiteGridOptionService gridOptionService;
        private readonly GridOptionBuilder gridOptionBuilder;

        public BingoSiteController(SiteService winlossService, SiteGridOptionService gridOptionService, GridOptionBuilder gridOptionBuilder)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
            this.gridOptionBuilder = gridOptionBuilder;
        }

        [Route("")]
        public IHttpActionResult Site(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildBasicGridOptions(gridOptions, queryModel.Site);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("Excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildBasicGridOptions(gridOptions, queryModel.Site);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}