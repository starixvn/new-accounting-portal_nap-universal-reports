using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.MatchDetail;

namespace UniversalReports.HouseWinLoss.Sportsbook.OutrightMatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/sportsbook/outright-match-detail")]
    public class SportsbookOutrightMatchDetailController : MatchDetailController
    {
        public SportsbookOutrightMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorOutright decorator)
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