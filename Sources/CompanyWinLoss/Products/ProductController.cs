using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
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
        public IHttpActionResult Values(QueryModel query)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = query.StartDate,
                    EndDate = query.EndDate
                };
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty, true);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelModel query)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = query.StartDate,
                    EndDate = query.EndDate
                };
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, query.Title, false);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}