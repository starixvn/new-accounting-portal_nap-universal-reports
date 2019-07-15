using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Common.MatchDetailByCode;

namespace UniversalReports.CN88WinLoss.NumberGame.MatchDetail
{
    [RoutePrefix("api/cn88-win-loss-by-products/number-game/match-detail")]
    public class CN88NumberGameMatchDetailController : CN88MatchDetailByCodeController
    {
        public CN88NumberGameMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
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