using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.HouseWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Soccer.LiveNonLive
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/live-nonlive")]
    public class SoccerLiveNonLiveController : BasicWinLossController
    {
        public SoccerLiveNonLiveController(
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
            return Json(criteria, "Live/Non-Live");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var majorMinorCriteria = CriteriaFactory.Transform<MajorMinor.Criteria>(queryModel);
            var majorMinorGridOptions = GetGridOptions(majorMinorCriteria, "Sport Type", queryModel.MajorMinorTitle);

            var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Sport Type", queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions },
                Constants.SheetName);
        }
    }
}