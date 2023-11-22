using System.Web.Http;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Products
{
    using Results;

    [RoutePrefix("api/cn88-win-loss-by-products/product")]
    public class CN88ProductController : ApiController
    {
        private readonly Service service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecoratorFull decorator;

        public CN88ProductController(Service service, GridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var winlosses = service.Query(queryModel);
            var gridOptions = builder.Build(winlosses, "Main");
            gridOptions = decorator.Build(gridOptions, "Products");

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var winlosses = service.Query(queryModel);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, "Products");
            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}