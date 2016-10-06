using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.MetricGaming.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/metric-gaming-superlive/match-detail")]
    public class MetricGamingMatchDetailController : MatchDetailController
    {
        public MetricGamingMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorFull decorator)
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