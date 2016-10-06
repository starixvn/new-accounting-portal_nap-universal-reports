using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;
using UniversalReports.Core.Factory;

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