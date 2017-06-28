using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/virtualsportsbetradar/match-detail")]
    public class VirtualSportsBetradarMatchDetailController : MatchDetailByCodeController
    {
        public VirtualSportsBetradarMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
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