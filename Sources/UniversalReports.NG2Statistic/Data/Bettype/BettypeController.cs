using System.Web.Http;
using UniversalReports.MVC.Results;

namespace UniversalReports.NG2Statistic.Data.Bettype
{
    [RoutePrefix("api/ng2-statistic/bettype")]
    public class BettypeController : ApiController
    {
        private readonly BettypeService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionHeaderColumn header;

        public BettypeController(BettypeService service, GridOptionsBuilder builder, GridOptionHeaderColumn header)
        {
            this.service = service;
            this.builder = builder;
            this.header = header;
        }

        [Route("")]
        public IHttpActionResult Bettype(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Bet Type", queryModel);

            return Json(gridOptions);
        }

        [Route("sort")]
        public IHttpActionResult Sort(QueryModel queryModel)
        {
            var dailyModel = service.SortData(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Bet Type", queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var dailyModel = service.Query(queryModel);
            var gridOptions = builder.Build(dailyModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, "Bet Type", queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistic");
        }
    }
}