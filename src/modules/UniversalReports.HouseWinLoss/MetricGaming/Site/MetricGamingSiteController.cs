using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;

namespace UniversalReports.HouseWinLoss.MetricGaming.Site
{
    [RoutePrefix("api/house-win-loss-by-products/metric-gaming-superlive/site")]
    public class MetricGamingSiteController : SiteWinLossController
    {
        public MetricGamingSiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
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
            return Excel(criteria, queryModel.Site, queryModel.Title);
        }
    }
}