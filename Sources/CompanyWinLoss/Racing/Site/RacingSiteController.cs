using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.Racing.Site
{
    [RoutePrefix("api/company-win-loss/racing/site")]
    public class RacingSiteController : SiteWinLossController
    {
        public RacingSiteController(WinLossService service, GridOptionBuilder builder, GridOptionColumnDecoratorBasic decorator)
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