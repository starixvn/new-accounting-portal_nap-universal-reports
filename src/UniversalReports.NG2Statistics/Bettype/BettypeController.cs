using System.Web.Http;
using UniversalReports.MVC.Results;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    [RoutePrefix("api/ng2-statistics/bettype")]
    public class BettypeController : ApiController
    {
        private readonly BettypeService service;
        private readonly GridOptionsBuilder builder;
        private readonly SortingService sorting;

        public BettypeController(BettypeService service, GridOptionsBuilder builder, SortingService sorting)
        {
            this.service = service;
            this.builder = builder;
            this.sorting = sorting;
        }

        [Route("")]
        public IHttpActionResult Bettype(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel);

            return Json(gridOptions);
        }

        [Route("sort")]
        public IHttpActionResult Sort(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            sorting.SortingData(dailyModel, queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            sorting.SortingData(dailyModel, queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistics");
        }
    }
}