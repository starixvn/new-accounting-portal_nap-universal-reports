using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportType
{
    [RoutePrefix("api/company-win-loss/virtual-sports/sport-type")]
    public class VirtualSportsSportTypeController : BasicWinLossController
    {
        public VirtualSportsSportTypeController(
            BasicWinLossService service,
            BasicGridOptionBuilder builder,
            GridOptionColumnDecoratorBasic decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "Sport Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "Sport Type", queryModel.Title);
        }
    }
}