using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    [RoutePrefix("api/company-win-loss/metric-gaming-superlive/bet-type")]
    public class MetricGamingBetTypeController : BasicWinLossController
    {
        public MetricGamingBetTypeController(
            BasicWinLossService service,
            BasicGridOptionBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "Bet Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }
    }
}
