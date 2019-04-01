using System.Web.Http;
using UniversalReports.MVC.Results;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Daily
{
    [RoutePrefix("api/ng2-statistics/daily")]
    public class DailyController : ApiController
    {
        private const string MainColumnName = "Winlostdate";

        private readonly DailyService service;
        private readonly GridOptionsBuilder builder;
        private readonly BaseGridOptionHeaderColumn header;

        public DailyController(DailyService service, GridOptionsBuilder builder, BaseGridOptionHeaderColumn header)
        {
            this.service = service;
            this.builder = builder;
            this.header = header;
        }

        [Route("")]
        public IHttpActionResult Daily(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Date", MainColumnName, queryModel);

            return Json(gridOptions);
        }

        [Route("sort")]
        public IHttpActionResult Sort(QueryModel queryModel)
        {
            var dailyRawModel = service.Query(queryModel);
            var dailyModel = service.SortData(dailyRawModel, queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Date", MainColumnName, queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            queryModel.SortColumnName = string.IsNullOrEmpty(queryModel.SortColumnName) ? MainColumnName : queryModel.SortColumnName;
            queryModel.SortDirection = string.IsNullOrEmpty(queryModel.SortDirection) ? "asc" : queryModel.SortDirection;

            var dailyModel = service.Query(queryModel);
            dailyModel = service.SortData(dailyModel, queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Date", MainColumnName, queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistics");
        }
    }
}