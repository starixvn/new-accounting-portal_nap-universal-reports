using Newtonsoft.Json;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    [RoutePrefix("api/company-win-loss/parlay/site")]
    public class ParlaySiteController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public ParlaySiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, string.Empty);
            gridOptions = decorator.Build(gridOptions, queryModel.Site);

            var result = Json(gridOptions);
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
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, queryModel.Site);

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}