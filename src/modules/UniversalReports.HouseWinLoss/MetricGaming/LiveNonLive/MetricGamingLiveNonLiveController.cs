using AutoMapper;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.MetricGaming.LiveNonLive
{
    [RoutePrefix("api/house-win-loss-by-products/metric-gaming-superlive/live-none-live")]
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
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Live/Non-Live", 220);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var betTypeCriteria = Mapper.Map<BetType.Criteria>(queryModel);
            var betTypeGridOptions = GetGridOptions(betTypeCriteria, "Bet Type", queryModel.BetTypeTitle, 220);

            var liveNonLiveCriteria = Mapper.Map<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle, 220);

            return new FanexExcelResult(new List<GridOptions> { betTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
        }
    }
}