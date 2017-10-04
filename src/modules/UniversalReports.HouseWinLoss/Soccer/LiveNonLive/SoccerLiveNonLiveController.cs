using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
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
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Live/Non-Live");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var majorMinorCriteria = Mapper.Map<MajorMinor.Criteria>(queryModel);
            var majorMinorGridOptions = GetGridOptions(majorMinorCriteria, "Major/Minor", queryModel.MajorMinorTitle);

            var liveNonLiveCriteria = Mapper.Map<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(
                new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions },
                Constants.SheetName);
        }
    }
}