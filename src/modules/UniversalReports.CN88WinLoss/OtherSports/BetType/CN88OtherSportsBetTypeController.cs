using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;

namespace UniversalReports.CN88WinLoss.OtherSports.BetType
{
    [RoutePrefix("api/cn88-win-loss-by-products/other-sports/bet-type")]
    public class CN88OtherSportsBetTypeController : CN88BasicWinLossController
    {
        public CN88OtherSportsBetTypeController(
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
            return Json(criteria, "Bet Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }
    }
}