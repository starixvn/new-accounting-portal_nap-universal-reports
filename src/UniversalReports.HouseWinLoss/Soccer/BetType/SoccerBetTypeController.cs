using System.Web.Http;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.Soccer.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/bettype")]
    public class SoccerBetTypeController : BasicWinLossController
    {
        public SoccerBetTypeController(
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
            return Json(criteria, "Bet Type", 210);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }
    }
}