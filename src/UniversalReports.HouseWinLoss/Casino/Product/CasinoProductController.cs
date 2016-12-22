using System.Web.Http;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.Casino.Product
{
    [RoutePrefix("api/house-win-loss-by-products/casino/product")]
    public class CasinoProductController : BasicWinLossController
    {
        public CasinoProductController(BasicWinLossService service, CasinoProductGridOptionsBuilder builder, GridOptionColumnDecoratorExtraPT decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "3rd Party Product");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "3rd Party Product", queryModel.Title);
        }
    }
}