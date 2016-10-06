using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.OtherSports.SportType
{
    [RoutePrefix("api/house-win-loss-by-products/other-sports/sport-type")]
    public class OtherSportsSportTypeController : BasicWinLossController
    {
        public OtherSportsSportTypeController(
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
