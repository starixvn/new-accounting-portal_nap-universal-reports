using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;

namespace UniversalReports.CN88WinLoss.OtherSports.SportType
{
    [RoutePrefix("api/cn88-win-loss-by-products/other-sports/sport-type")]
    public class CN88OtherSportsSportTypeController : CN88BasicWinLossController
    {
        public CN88OtherSportsSportTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorFull decorator)
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