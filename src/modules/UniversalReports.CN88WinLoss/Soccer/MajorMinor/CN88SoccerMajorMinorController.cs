using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;

namespace UniversalReports.CN88WinLoss.Soccer.MajorMinor
{
    [RoutePrefix("api/cn88-win-loss-by-products/soccer/major-minor")]
    public class CN88SoccerMajorMinorController : CN88BasicWinLossController
    {
        public CN88SoccerMajorMinorController(
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
            return Json(criteria, "Major/Minor");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Major/Minor", queryModel.Title);
        }
    }
}