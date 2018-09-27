using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.SportType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/sport-type")]
    public class SoccerMinorSportTypeController : BasicWinLossController
    {
        public SoccerMinorSportTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Sport Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Sport Type", queryModel.Title);
        }
    }
}