using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;

namespace UniversalReports.HouseWinLoss.VirtualSports.RacingDetail
{
    [RoutePrefix("api/house-win-loss-by-products/virtual-sports/racing-match-detail")]
    public class VirtualSportsRacingDetailController : MatchDetailByCodeController
    {
        public VirtualSportsRacingDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
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