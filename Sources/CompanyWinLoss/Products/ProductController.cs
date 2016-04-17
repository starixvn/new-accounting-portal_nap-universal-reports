using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Products
{
    [RoutePrefix("api/company-win-loss/product")]
    public class ProductController : ApiController
    {
        private readonly Service service;

        private readonly GridOptionBuilder builder;

        private readonly GridOptionColumnDecoratorFull decorator;

        public ProductController(Service service, GridOptionBuilder builder, GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Values(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.Build(winlosses, "Main", true);
                gridOptions = decorator.Build(gridOptions, "Products", 170);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.Build(winlosses, queryModel.Title, false);
                return new FanexExcelResult(gridOptions, Common.Constants.SheetName);
            }

            return null;
        }
    }
}