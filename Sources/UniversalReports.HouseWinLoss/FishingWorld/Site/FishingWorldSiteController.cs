using System.Web.Http;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.SiteWinLoss;

namespace UniversalReports.HouseWinLoss.FishingWorld.Site
{
    [RoutePrefix("api/house-win-loss-by-products/fishing-world/site")]
    public class FishingWorldSiteController : SiteWinLossController
    {
        public FishingWorldSiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, queryModel.Site);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, queryModel.Site, queryModel.Title);
        }
    }
}