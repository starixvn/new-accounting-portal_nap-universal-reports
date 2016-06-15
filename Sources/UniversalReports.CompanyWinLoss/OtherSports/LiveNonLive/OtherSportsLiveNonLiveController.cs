using Fanex.Excel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/other-sports/live-non-live")]
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
            var result = Json(criteria, "Live/Non-Live");
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
            var sportTypeCriteria = CriteriaFactory.Transform<SportType.Criteria>(queryModel);
            var sportTypeGridOptions = GetGridOptions(sportTypeCriteria, "Sport Type", queryModel.SportTypeTitle);

            var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(new List<GridOptions> { sportTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
        }
    }
}