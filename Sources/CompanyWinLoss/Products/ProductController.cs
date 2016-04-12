using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Products
{
    [RoutePrefix("api/company-win-loss/product")]
    public class ProductController : ApiController
    {
        private readonly Service _service;
        private readonly GridOptionService _gridOptionService;

        public ProductController(Service service, GridOptionService gridOptionService)
        {
            this._service = service;
            this._gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult Values(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = _service.Query(criteria);
                var gridOptions = _gridOptionService.FromWinLossModel(winlosses, "Main", true);

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
                var winlosses = _service.Query(criteria);
                var gridOptions = _gridOptionService.FromWinLossModel(winlosses, queryModel.Title, false);
                return new FanexExcelResult(gridOptions, Common.Constants.SheetName);
            }

            return null;
        }
    }
}