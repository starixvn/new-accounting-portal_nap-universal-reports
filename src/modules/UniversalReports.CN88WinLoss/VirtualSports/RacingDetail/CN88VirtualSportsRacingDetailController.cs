using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Common.MatchDetailByCode;

namespace UniversalReports.CN88WinLoss.VirtualSports.RacingDetail
{
    [RoutePrefix("api/cn88-win-loss-by-products/virtual-sports/racing-match-detail")]
    public class CN88VirtualSportsRacingDetailController : CN88MatchDetailByCodeController
    {
        public CN88VirtualSportsRacingDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
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