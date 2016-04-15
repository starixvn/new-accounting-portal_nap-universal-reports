using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/other-sports/live-non-live")]
    public class OtherSportsLiveNonLiveController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;
        private readonly GridOptionBuilder gridOptionBuilder;

        public OtherSportsLiveNonLiveController(BasicWinLossService winlossService, BasicGridOptionService gridOptionService, GridOptionBuilder gridOptionBuilder)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
            this.gridOptionBuilder = gridOptionBuilder;
        }

        [Route("")]
        public IHttpActionResult LiveNonLive(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildVirtualGridOptions(gridOptions, "Live/Non-Live");

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var sportTypeCriteria = CriteriaFactory.Transform<SportType.Criteria>(queryModel);
                var sportTypeWinlosses = winlossService.Query(sportTypeCriteria);
                var sportTypeGridOptions = gridOptionService.FromWinLossModel(sportTypeWinlosses, queryModel.SportTypeTitle);
                sportTypeGridOptions = gridOptionBuilder.BuildVirtualGridOptions(sportTypeGridOptions, "Sport Type");

                var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var liveNonLiveWinlosses = winlossService.Query(liveNonLiveCriteria);
                var liveNonLiveGridOptions = gridOptionService.FromWinLossModel(liveNonLiveWinlosses, queryModel.LiveNonLiveTitle);
                liveNonLiveGridOptions = gridOptionBuilder.BuildVirtualGridOptions(liveNonLiveGridOptions, "Live/Non-Live");

                return new FanexExcelResult(new List<GridOptions> { sportTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
            }

            return null;
        }
    }
}