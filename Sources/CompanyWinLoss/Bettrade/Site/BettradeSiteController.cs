using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.Bettrade.Site
{
    [RoutePrefix("api/company-win-loss/bettrade/site")]
    public class BettradeSiteController : SiteWinLossController
    {
        public BettradeSiteController(WinLossService service, GridOptionBuilder builder, GridOptionColumnDecorator decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Site(QueryModel queryModel)
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