using System.Web.Http;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;

namespace UniversalReports.HouseWinLoss.NumberGame.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/number-game/match-detail")]
    public class NumberGameMatchDetailController : MatchDetailByCodeController
    {
        public NumberGameMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, queryModel.Title);
        }
    }
}