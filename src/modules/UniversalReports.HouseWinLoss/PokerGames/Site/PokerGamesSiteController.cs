using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.PokerGames.Site
{
    [RoutePrefix("api/house-win-loss-by-products/poker-games/site")]
    public class PokerGamesSiteController : SiteWinLossController
    {
        public PokerGamesSiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, queryModel.Site);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, queryModel.Site, queryModel.Title, Constants.SheetName);
        }
    }
}