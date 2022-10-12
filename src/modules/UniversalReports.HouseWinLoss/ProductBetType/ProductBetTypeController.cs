using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.ProductBetType
{
    [RoutePrefix("api/house-win-loss-by-products/product-bettype")]
    public class ProductBetTypeController : ApiController
    {
        private readonly Service service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecoratorFull decorator;

        public ProductBetTypeController(Service service, GridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var winlosses = service.Query(queryModel);
            var gridOptions = builder.Build(winlosses, "Bet Type");
            gridOptions = decorator.Build(gridOptions, "Bet Type");

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var winlosses = service.Query(queryModel);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, "Bet Type");
            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}
