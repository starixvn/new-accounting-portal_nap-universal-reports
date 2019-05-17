using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.MetricGaming.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/metric-gaming-superlive/bet-type")]
    public class MetricGamingBetTypeController : BasicWinLossController
    {
        public MetricGamingBetTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorFull decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            const int mainColumnWidth = 220;
            return Json(criteria, "Bet Type", mainColumnWidth);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            const int mainColumnWidth = 220;
            return Excel(criteria, "Bet Type", queryModel.Title, mainColumnWidth);
        }
    }
}