using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetail;

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
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, queryModel.Title);
        }
    }
}