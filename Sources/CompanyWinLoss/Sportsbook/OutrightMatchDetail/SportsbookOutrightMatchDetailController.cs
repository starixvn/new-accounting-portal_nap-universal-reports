using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail
{
    [RoutePrefix("api/company-win-loss/sportsbook/outright-match-detail")]
    public class SportsbookOutrightMatchDetailController : MatchDetailController
    {
        public SportsbookOutrightMatchDetailController(WinLossService service, GridOptionBuilder builder, MatchGridOptionColumnDecoratorOutright decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, queryModel.Title);
        }
    }
}