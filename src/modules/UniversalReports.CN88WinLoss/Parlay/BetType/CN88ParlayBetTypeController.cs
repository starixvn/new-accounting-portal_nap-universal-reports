using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;

namespace UniversalReports.CN88WinLoss.Parlay.BetType
{
    [RoutePrefix("api/cn88-win-loss-by-products/parlay/bet-type")]
    public class CN88ParlayBetTypeController : CN88BasicWinLossController
    {
        public CN88ParlayBetTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
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