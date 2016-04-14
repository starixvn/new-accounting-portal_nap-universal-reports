using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/metric-gaming-superlive/live-none-live")]
    public class MetricGamingLiveNonLiveController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;
        private readonly GridOptionBuilder gridOptionBuilder;

        public MetricGamingLiveNonLiveController(BasicWinLossService winlossService, BasicGridOptionService gridOptionService, GridOptionBuilder gridOptionBuilder)
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
                gridOptions = gridOptionBuilder.BuildBasicGridOptions(gridOptions, "Live/Non-Live");

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var betTypeCriteria = CriteriaFactory.Transform<BetType.Criteria>(queryModel);
                var betTypeWinlosses = winlossService.Query(betTypeCriteria);
                var betTypeGridOptions = gridOptionService.FromWinLossModel(betTypeWinlosses, queryModel.BetTypeTitle);
                betTypeGridOptions = gridOptionBuilder.BuildBasicGridOptions(betTypeGridOptions, "Bet Type");

                var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var liveNonLiveWinlosses = winlossService.Query(liveNonLiveCriteria);
                var liveNonLiveGridOptions = gridOptionService.FromWinLossModel(liveNonLiveWinlosses, queryModel.LiveNonLiveTitle);
                betTypeGridOptions = gridOptionBuilder.BuildBasicGridOptions(betTypeGridOptions, "Live/Non-Live");

                return new FanexExcelResult(new List<GridOptions> { betTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
            }

            return null;
        }
    }
}
