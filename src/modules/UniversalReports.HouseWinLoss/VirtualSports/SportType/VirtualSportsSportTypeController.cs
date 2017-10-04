using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportType
{
    [RoutePrefix("api/house-win-loss-by-products")]
    public class VirtualSportsSportTypeController : BasicWinLossController
    {
        public VirtualSportsSportTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorBasic decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("virtual-sports/sport-type")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Sport Type");
        }

        [Route("virtual-sports/sport-type/excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Sport Type", queryModel.Title);
        }
    }
}