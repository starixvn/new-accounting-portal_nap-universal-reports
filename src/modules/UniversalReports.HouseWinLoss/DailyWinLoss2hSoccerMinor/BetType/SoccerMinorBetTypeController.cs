using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/bet-type")]
    public class SoccerMinorBetTypeController : BasicWinLossController
    {
        public SoccerMinorBetTypeController(
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
            const int mainColumnWidth = 210;
            return Json(criteria, "Bet Type", mainColumnWidth);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            const int mainColumnWidth = 210;
            return Excel(criteria, "Bet Type", queryModel.BetTypeFullTitle, mainColumnWidth);
        }
    }
}