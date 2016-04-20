using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
//using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.Parlay.SiteService;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    [RoutePrefix("api/company-win-loss/parlay/site")]
    public class ParlaySiteController : SiteServiceController
    {
        public ParlaySiteController(SiteWinLossService service, GridOptionBuilderSite builder, GridOptionColumnDecoratorVirtual decorator)
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