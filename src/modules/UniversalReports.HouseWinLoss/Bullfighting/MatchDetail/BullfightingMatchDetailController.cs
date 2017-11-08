using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetail3rd;

namespace UniversalReports.HouseWinLoss.Bullfighting.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/bullfighting/match-detail")]
    public class BullfightingMatchDetailController : MatchDetail3rdController
    {
        public BullfightingMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecorator3rd decorator)
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