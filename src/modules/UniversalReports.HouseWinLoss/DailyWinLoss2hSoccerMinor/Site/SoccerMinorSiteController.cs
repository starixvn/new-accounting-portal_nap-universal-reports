using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
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
            var criteria = Mapper.Map<UniversalSportbookSiteCriteria>(queryModel);
            return Json(criteria, queryModel.SiteType);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalSportbookSiteCriteria>(queryModel);
            return Excel(criteria, queryModel.SiteType, queryModel.Title, Constants.SoccerMinorBetTypesSheetName);
        }
    }
}