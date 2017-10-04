using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.CashOut.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/cash-out/bet-type")]
    public class CashOutBetTypeController : BasicWinLossController
    {
        public CashOutBetTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecorator decorator)
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