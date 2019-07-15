using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Common.MatchDetail;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.VirtualSports.SportsbookDetail
{
    [RoutePrefix("api/cn88-win-loss-by-products/virtual-sports/sportsbook-match-detail")]
    public class CN88VirtualSportsSportsbookDetailController : CN88MatchDetailController
    {
        public CN88VirtualSportsSportsbookDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorBasic decorator)
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