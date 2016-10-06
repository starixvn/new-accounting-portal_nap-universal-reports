using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.Soccer.MajorMinor
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/major-minor")]
    public class SoccerMajorMinorController : BasicWinLossController
    {
        public SoccerMajorMinorController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "Major/Minor");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, "Major/Minor", queryModel.Title);
        }
    }
}
