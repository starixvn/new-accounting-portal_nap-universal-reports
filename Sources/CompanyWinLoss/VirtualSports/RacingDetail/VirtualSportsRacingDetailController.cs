using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Common.MatchDetailByCode;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    [RoutePrefix("api/company-win-loss/virtual-sports/racing-match-detail")]
    public class VirtualSportsRacingDetailController : MatchDetailByCodeController
    {
        public VirtualSportsRacingDetailController(WinLossService service, GridOptionBuilder builder, MatchGridOptionColumnDecoratorBasic decorator)
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