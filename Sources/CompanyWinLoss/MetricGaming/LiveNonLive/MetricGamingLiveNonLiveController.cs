using System.Collections.Generic;
using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/metric-gaming/live-none-live")]
    public class MetricGamingLiveNonLiveController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;

        public MetricGamingLiveNonLiveController(BasicWinLossService winlossService, BasicGridOptionService gridOptionService)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult LiveNonLive(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty, "Live/Non-Live");

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
                var betTypeGridOptions = gridOptionService.FromWinLossModel(betTypeWinlosses, queryModel.BetTypeTitle, "Bet Type");
                var liveNoneLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var liveNoneLiveWinlosses = winlossService.Query(liveNoneLiveCriteria);
                var liveNoneLiveGridOptions = gridOptionService.FromWinLossModel(liveNoneLiveWinlosses, queryModel.LiveNonLiveTitle, "Live/Non-Live");
                return new FanexExcelResult(new List<GridOptions> { betTypeGridOptions, liveNoneLiveGridOptions }, Constants.SheetName);
            }
            return null;
        }
    }
}
