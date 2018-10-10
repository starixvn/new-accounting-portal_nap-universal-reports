using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.VirtualSportsBetradar.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/virtual-sports-betradar/match-detail")]
    public class VirtualSportsBetradarMatchDetailController : MatchDetailController
    {
        public VirtualSportsBetradarMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorBasic decorator)
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
            return Excel(criteria, queryModel.Title, Constants.SheetName);
        }
    }
}