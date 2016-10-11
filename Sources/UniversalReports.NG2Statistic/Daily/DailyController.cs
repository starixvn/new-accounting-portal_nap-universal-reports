using System.Web.Http;
using UniversalReports.MVC.Results;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Daily
{
    [RoutePrefix("api/ng2-statistic/daily")]
    public class DailyController : ApiController
    {
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
            gridOptions = header.Build(gridOptions, "Date", "Winlostdate", queryModel);

            return Json(gridOptions);
        }

        [Route("sort")]
        public IHttpActionResult Sort(QueryModel queryModel)
        {
            var dailyRawModel = service.Query(queryModel);
            var dailyModel = service.SortData(dailyRawModel, queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Date", "Winlostdate", queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Date", "Winlostdate", queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistic");
        }
    }
}