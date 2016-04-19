using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.LiveCasino.Product
{
    [RoutePrefix("api/company-win-loss/live-casino/third-party-product")]
    public class LiveCasinoProductController : BasicWinLossController
    {
        public LiveCasinoProductController(BasicWinLossService service, BasicGridOptionBuilder builder, GridOptionColumnDecoratorExtraPT decorator)
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