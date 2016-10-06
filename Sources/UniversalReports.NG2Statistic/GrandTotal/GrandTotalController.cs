using System.Web.Http;
using UniversalReports.MVC.Results;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    [RoutePrefix("api/ng2-statistic/grandtotal")]
    public class GrandTotalController : ApiController
    {
        private readonly GrandTotalService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionHeaderColumn header;

        public GrandTotalController(GrandTotalService service, GridOptionsBuilder builder, GridOptionHeaderColumn header)
        {
            this.service = service;
            this.builder = builder;
            this.header = header;
        }

        [Route("")]
        public IHttpActionResult GrandTotal(QueryModel queryModel)
        {
            var grandTotalModel = service.Query(queryModel);
            var gridOptions = builder.Build(grandTotalModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var grandTotalModel = service.Query(queryModel);
            var gridOptions = builder.Build(grandTotalModel, queryModel.Title);
            gridOptions = header.Build(gridOptions, queryModel);

            return new FanexExcelResult(gridOptions, "NG2 Statistic");
        }
    }
}