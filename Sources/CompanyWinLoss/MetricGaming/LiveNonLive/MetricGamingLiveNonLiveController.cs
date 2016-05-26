using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/metric-gaming-superlive/live-none-live")]
    public class MetricGamingLiveNonLiveController : BasicWinLossController
    {
        public MetricGamingLiveNonLiveController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "Live/Non-Live", 200);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var betTypeCriteria = CriteriaFactory.Transform<BetType.Criteria>(queryModel);
                var betTypeGridOptions = GetGridOptions(betTypeCriteria, "Bet Type", queryModel.BetTypeTitle, 200);

                var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle, 200);

                return new FanexExcelResult(new List<GridOptions> { betTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
            }

            return null;
        }
    }
}
