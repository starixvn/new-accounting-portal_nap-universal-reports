using System.Web.Http;
using UniversalReports.MVC.Results;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    [RoutePrefix("api/ng2-statistic/daily")]
    public class DailyController : ApiController
    {
        private readonly DailyService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionHeaderColumn header;

        public DailyController(DailyService service, GridOptionsBuilder builder, GridOptionHeaderColumn header)
        {
            this.service = service;
            this.builder = builder;
            this.header = header;
        }

        [Route("")]
        public IHttpActionResult Daily(DailyCriteria criteria)
        {
            var dailyModel = service.Query(criteria);
            var gridOptions = builder.Build(dailyModel, criteria.Title);
            gridOptions = header.Build(gridOptions, "Date", 100);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(DailyCriteria criteria)
        {
            var dailyModel = service.Query(criteria);
            var gridOptions = builder.Build(dailyModel, criteria.Title);
            gridOptions = header.Build(gridOptions, "Date", 100);

            return new FanexExcelResult(gridOptions, "NG2 Statistic");
        }
    }
}