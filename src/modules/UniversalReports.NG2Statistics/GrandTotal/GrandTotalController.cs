using System.Web.Http;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    using Results;

    [RoutePrefix("api/ng2-statistics/grandtotal")]
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
            gridOptions = header.Build(gridOptions);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(QueryModel queryModel)
        {
            var grandTotalModel = service.Query(queryModel);
            var gridOptions = builder.Build(grandTotalModel, queryModel.Title);
            gridOptions = header.Build(gridOptions);

            return new FanexExcelResult(gridOptions, "NG2 Statistics");
        }
    }
}