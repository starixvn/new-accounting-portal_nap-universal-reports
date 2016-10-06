using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.Racing.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/racing/match-detail")]
    public class RacingMatchDetailController : MatchDetailByCodeController
    {
        public RacingMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
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