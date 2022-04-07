using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Sportsbook.Site
{
    [RoutePrefix("api/house-win-loss-by-products/sportsbook/site")]
    public class SportsbookSiteController : SiteWinLossController
    {
        public SportsbookSiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, queryModel.SiteType);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, queryModel.SiteType, queryModel.Title, Constants.SheetName);
        }
    }
}