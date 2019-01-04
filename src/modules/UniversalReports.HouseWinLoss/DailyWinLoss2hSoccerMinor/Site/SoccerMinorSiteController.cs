using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.Site
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/site")]
    public class SoccerMinorSiteController : SiteWinLossController
    {
        public SoccerMinorSiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
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
            return Excel(criteria, queryModel.Site, queryModel.Title, Constants.SoccerMinorBetTypesSheetName);
        }
    }
}