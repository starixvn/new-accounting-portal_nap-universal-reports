using System.Web.Http;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Products
{
    [RoutePrefix("api/company-win-loss/product")]
    public class ProductController : ApiController
    {
        private readonly Service service;
        private readonly GridOptionService gridOptionService;

        public ProductController(Service service, GridOptionService gridOptionService)
        {
            this.service = service;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult Values(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, "Main", true);

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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title, false);
                return new FanexExcelResult(gridOptions, Common.Constants.SheetName);
            }

            return null;
        }
    }
}