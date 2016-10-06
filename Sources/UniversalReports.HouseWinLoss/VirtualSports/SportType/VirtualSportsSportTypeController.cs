using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.Core.Factory;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportType
{
    [RoutePrefix("api/house-win-loss-by-products/virtual-sports/sport-type")]
    public class VirtualSportsSportTypeController : BasicWinLossController
    {
        public VirtualSportsSportTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
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