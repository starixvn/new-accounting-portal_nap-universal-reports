using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.Core.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.OtherSports.LiveNonLive
{
    [RoutePrefix("api/house-win-loss-by-products/other-sports/live-non-live")]
    public class OtherSportsLiveNonLiveController : BasicWinLossController
    {
        public OtherSportsLiveNonLiveController(
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
            var sportTypeCriteria = CriteriaFactory.Transform<SportType.Criteria>(queryModel);
            var sportTypeGridOptions = GetGridOptions(sportTypeCriteria, "Sport Type", queryModel.SportTypeTitle);

            var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(new List<GridOptions> { sportTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
        }
    }
}