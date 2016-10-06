using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.OtherSports.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/other-sports/bet-type")]
    public class OtherSportsBetTypeController : BasicWinLossController
    {
        public OtherSportsBetTypeController(
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
            return Json(criteria, "Bet Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }
    }
}
