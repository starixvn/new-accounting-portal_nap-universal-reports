using Fanex.Excel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/metric-gaming-superlive/live-none-live")]
    public class MetricGamingLiveNonLiveController : BasicWinLossController
    {
        public MetricGamingLiveNonLiveController(
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
            var result = Json(criteria, "Live/Non-Live", 220);
            var fileName = queryModel.GetType().FullName;
            var criteriaFileName = "D:\\" + fileName + "-queryModel.json";
            var resultFileName = "D:\\" + fileName + "-expected.json";
            var json = JsonConvert.SerializeObject(queryModel, Formatting.Indented);
            System.IO.File.WriteAllText(criteriaFileName, json);
            json = JsonConvert.SerializeObject((result as System.Web.Http.Results.JsonResult<Fanex.Excel.Models.GridOptions>).Content, Formatting.Indented);
            System.IO.File.WriteAllText(resultFileName, json);
            return result;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var betTypeCriteria = CriteriaFactory.Transform<BetType.Criteria>(queryModel);
            var betTypeGridOptions = GetGridOptions(betTypeCriteria, "Bet Type", queryModel.BetTypeTitle, 220);

            var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle, 220);

            return new FanexExcelResult(new List<GridOptions> { betTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
        }
    }
}
