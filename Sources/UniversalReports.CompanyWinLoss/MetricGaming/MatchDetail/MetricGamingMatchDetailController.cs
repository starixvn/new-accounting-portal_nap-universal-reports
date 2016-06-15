using Newtonsoft.Json;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    [RoutePrefix("api/company-win-loss/metric-gaming-superlive/match-detail")]
    public class MetricGamingMatchDetailController : MatchDetailController
    {
        public MetricGamingMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorFull decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var result = Json(criteria);
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
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Excel(criteria, queryModel.Title);
        }
    }
}